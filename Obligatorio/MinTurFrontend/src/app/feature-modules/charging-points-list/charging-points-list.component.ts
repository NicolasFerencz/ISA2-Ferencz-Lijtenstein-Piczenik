import { ChargingPointsService } from 'src/app/core/http-services/charging-points/charging-points.service';
import { RegionService } from 'src/app/core/http-services/region/region.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChargingPointsModel } from 'src/app/shared/models/in/charging-points-model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-charging-points-list',
  templateUrl: './charging-points-list.component.html',
  styleUrls: []
})
export class ChargingPointsListComponent implements OnInit {
  public chargingPoints: ChargingPointsModel[] = [];
  public regions;
  public displayError: boolean;
  public newCP;
  public cpmessage = null;
  public deletemessage = null;

  constructor(private chargingPointsService: ChargingPointsService, private regionService: RegionService, private router: Router) {
    this.newCP = {
      description: '',
      name: null,
      address: '',
      region: 'Seleccione una region',
      identificator: 1000,
    };
  }

  ngOnInit(): void {
    this.retrieveComponentData();
    this.getRegions()
  }

  private retrieveComponentData(): void{
    this.chargingPointsService.allChargingPoints()
      .subscribe(cps => this.loadCPs(cps), (error: HttpErrorResponse) => this.showError(error));
  }

  private loadCPs(cps: ChargingPointsModel[]): void{
    this.chargingPoints = cps;
  }

  public deleteCP(id: number): void {
    this.chargingPointsService.deleteOneChargingPoint(id)
      .subscribe((response) => {
        this.retrieveComponentData()
        this.deletemessage = 'Punto de carga eliminado correctamente'
      },(error: HttpErrorResponse) => this.showError(error));
  }

  public closeError(): void{
    this.displayError = false;
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }

  private invalid(input:string, max:number, aphn: boolean) {
    return input === null || input === '' || input.length > max || (aphn && !this.alphaNumerical(input));
  }

  private alphaNumerical(input: string) {
    return input.split('').every((c, i) => {
      const code = input.charCodeAt(i);
      if (code === 32) return true;
      if (48 <= code && code <= 57) return true;
      if (65 <= code && code <= 90) return true;
      if (97 <= code && code <= 122) return true;
      return false;
    })
  }

  public createCP() {
    this.deletemessage = null;
    if (this.newCP.identificator < 1000 || this.newCP.identificator > 9999){
      this.cpmessage = 'El identificador debe ser un numero de 4 digitos';
      return;
    }
    if (this.invalid(this.newCP.name, 20, true)){
      this.cpmessage = 'El nombre debe contener solo letras y numeros y tener un maximo 20 caracteres';
      return;
    }
    if (this.invalid(this.newCP.address, 60, true)){
      this.cpmessage = 'La direccion debe contener solo letras y numeros y tener un maximo 60 caracteres';
      return;
    }
    if (this.invalid(this.newCP.description, 30, false)){
      this.cpmessage = 'La descripcion debe tener un maximo 30 caracteres';
      return;
    }
    if (this.chargingPoints.find(cp => cp.identificator === this.newCP.identificator)) {
      this.cpmessage = 'El identificador ya existe';
      return
    }
    if (this.newCP.region === 'Seleccione una region') {
      this.cpmessage = 'Seleccione una región';
      return
    }
    const regionId = this.regions.find(r => r.name === this.newCP.region).id
    try {
      this.chargingPointsService.createOneChargingPoint({ ...this.newCP, regionId})
      .subscribe((response) => { 
        this.retrieveComponentData()
        this.cpmessage = 'Punto de carga creado correctamente!';
      })
    } catch (err) {
      console.log('err', err);
    }
  }

  private getRegions(): void {
    this.regionService.allRegions().subscribe(regions => {
        this.regions = regions
      },
      error => this.showError(error)
    );
  }

}
