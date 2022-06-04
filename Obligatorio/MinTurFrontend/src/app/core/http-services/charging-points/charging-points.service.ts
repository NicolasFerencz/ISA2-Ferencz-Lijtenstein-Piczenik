import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ChargingPointsEndpoints } from '../endpoints';
import { ChargingPointsModel } from 'src/app/shared/models/in/charging-points-model';
import { format } from 'util';

@Injectable({
  providedIn: 'root'
})
export class ChargingPointsService {
  constructor(private http: HttpClient) { }

  public allChargingPoints(): Observable<ChargingPointsModel[]>{
    let allCPUri = format(ChargingPointsEndpoints.GET_CHARGINGPOINTS);
    return this.http.get<ChargingPointsModel[]>(allCPUri);
  }

  public createOneChargingPoint(chargingPointsModel: ChargingPointsModel): Observable<ChargingPointsModel>{
    return this.http.post<ChargingPointsModel>(ChargingPointsEndpoints.CREATE_CHARGINGPOINTS, chargingPointsModel);
  }

  public deleteOneChargingPoint(id: number): Observable<void>{
    return this.http.delete<void>(format(ChargingPointsEndpoints.DELETE_CHARGINGPOINTS, id));
  }
}
