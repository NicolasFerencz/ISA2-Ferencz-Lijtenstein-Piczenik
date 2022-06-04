Feature: Test Puntos de carga

  Scenario: Creo un punto de carga sin datos
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Registro el punto de carga
    Then Veo el mensaje "El nombre debe contener solo letras y numeros y tener un maximo 20 caracteres"

  Scenario: Creo un punto de carga sin direccion
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Registro el punto de carga
    Then Veo el mensaje "La direccion debe contener solo letras y numeros y tener un maximo 60 caracteres"

  Scenario: Creo un punto de carga sin descripcion
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Ingreso el nombre "el mejor" en el campo "direccion"
    When Registro el punto de carga
    Then Veo el mensaje "La descripcion debe tener un maximo 30 caracteres"

  Scenario: Creo un punto de com identificador de 3 digitos
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "999" en el campo "identificador"
    When Registro el punto de carga
    Then Veo el mensaje "El identificador debe ser un numero de 4 digitos"

  Scenario: Creo un punto de carga exitosamente
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Ingreso el nombre "el mejor" en el campo "descripcion"
    When Ingreso el nombre "Av Brasil" en el campo "direccion"
    When Ingreso el nombre "1989" en el campo "identificador"
    When Hago click en la region "2"
    When Registro el punto de carga
    Then Veo el mensaje "Punto de carga creado correctamente!"

  Scenario: Creo un punto de carga con un id que ya existe
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Ingreso el nombre "el mejor" en el campo "descripcion"
    When Ingreso el nombre "Av Brasil" en el campo "direccion"
    When Ingreso el nombre "1989" en el campo "identificador"
    When Registro el punto de carga
    Then Veo el mensaje "El identificador ya existe" 

  Scenario: Creo un punto de carga con direccion no alfanumérica
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Ingreso el nombre "el mejor" en el campo "descripcion"
    When Ingreso el nombre "Av. Brasil" en el campo "direccion"
    When Ingreso el nombre "1939" en el campo "identificador"
    When Hago click en la region "2"
    When Registro el punto de carga
    Then Veo el mensaje "La direccion debe contener solo letras y numeros y tener un maximo 60 caracteres"

  Scenario: Elimino punto de carga exitosamente
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Elimino el punto de carga con identificador "1989"
    Then Veo que se elimino el punto de carga correctamente

  Scenario: Creo un punto de carga sin especificar region
    Given Entro a la pagina "http://localhost:4200/admin/charging-points"
    When Ingreso el nombre "punto de carga" en el campo "nombre"
    When Ingreso el nombre "el mejor" en el campo "descripcion"
    When Ingreso el nombre "Av Brasil" en el campo "direccion"
    When Ingreso el nombre "1100" en el campo "identificador"
    When Registro el punto de carga
    Then Veo el mensaje "Seleccione una región" 

