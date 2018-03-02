' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se anexo el mensaje 93

' Modifico: Claudia Aurora García Patiño
' Fecha: 16 de Febreo del 2007
' Motivo: Se anexo el mensaje 95

Public Class Mensaje
    Private _Mensaje As String

    Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal Value As String)
            _Mensaje = Value
        End Set
    End Property

    'Modificó: Carlos Nirari Santiago Mendoza
    'Fecha: 27/06/2015
    'Descripción: Se modifico el metodo, para agregar mensajes pertenecientes a la liquidacion portatil por remision
    'Id. de cambios: 20150627CNSM$001

    Protected Function Mensajes(ByVal NumeroMensaje As Integer, ByVal Texto As String) As String
        Select Case NumeroMensaje
            Case 1
                Return "Las existencias del almacen origen no son suficientes, para realizar la carga, por favor disminuya la cantidad de carga."
            Case 2
                Return "La carga no se puede realizar, la ruta no ha liquidado."
            Case 3
                Return "El número de cliente " & Texto & " no existe o no están completos los datos, intentelo de nuevo."
            Case 4
                Return "¿La información es correcta?"
            Case 5
                Return "La carga sobre pasa la existencia máxima del almacen destino, por favor disminuya la carga."
            Case 6
                Return "Litros al 100 debe de ser mayor a litros PEMEX, por favor corrija los datos para continuar."
            Case 7
                Return "El porcentaje inicial debe de ser mayor al porcentaje final, por favor corrija los datos para continuar."
            Case 8
                Return "El peso tara lleno debe de ser mayor al peso tara vació, por favor corrija los datos para continuar."
            Case 9
                Return "El totalizador final debe de ser mayor al totalizador inicial, por favor corrija los datos para continuar."
            Case 10
                Return "La dendidad del gas L.P. es menor que 1, por favor corrija los datos para continuar."
            Case 11
                Return "No existen registros a mostrar."
            Case 12
                Return "No existe el formato del ticket de carga o no tiene acceso a la carpeta, intente imprimir más tarde, la información ha sido registrada correctamente."
            Case 13
                Return "No se imprimio el ticket, intente imprimir más tarde, la información ha sido registrada correctamente."
            Case 14
                Return "¿Esta seguro de continuar?"
            Case 15
                Return "El empleado con número de nomina " & Texto & " no existe."
            Case 16
                Return "No hay datos a mostrar."
            Case 17
                Return "El reporte " & Texto & " no puede ser ejecutando en este momento, intente más tarde."
            Case 18
                Return "El movimiento esta INACTIVO, por lo cual no puede ser impreso."
            Case 19
                Return "No existe el formato del reporte o no tiene acceso a la carpeta, intente imprimir más tarde."
            Case 20
                Return "No se pueden cancelar, los folios ya han sido cancelados anteriormente."
            Case 21
                Return "No se pueden cancelar los folios que no han sido asignados, solo se pueden cancelar los folios asignados."
            Case 22
                Return "No se pueden regsitrar, los folios ya han sido " & Texto & " anteriormente."
            Case 23
                Return "El folio inicial debe de ser menor o igual al folio final."
            Case 24
                Return "No tiene privilegios para visualizar reportes."
            Case 25
                Return "No se pueden registrar los folios que no han sido asignados, solo se pueden registrar como devueltos los folios asignados."
            Case 26
                Return "La fecha de " & Texto & " debe de ser la mayor o igual a la fecha de asignación."
            Case 27
                Return "Los folios asignados que ya han sido devueltos no se pueden modificar."
            Case 28
                Return "¿Esta seguro de querer cerrar la ventana?"
            Case 29
                Return "El empleado que desea agregar ya esta en la tripulación."
            Case 30
                Return "Por favor seleccione el almacén de gas al que se asignará la tripulación."
            Case 31
                Return "Por favor agregue al menos un empleado a la tripulación."
            Case 32
                Return "La tripulación que intenta dar de alta ya existe en este almacén."
            Case 33
                Return "La tripulación no puede ser modificada o eliminada."
            Case 34
                Return "Por favor escriba el nombre con el que se registrará el corporativo."
            Case 35
                Return "Por favor escriba la abreviación con la cuál se identificará el corporativo."
            Case 36
                Return "No puede agregar más de un operador a la tripulación."
            Case 37
                Return "No puede agregar más de un supervisor a la tripulación."
            Case 38
                Return "Por favor escriba la descripción del tanque que dará de alta."
            Case 39
                Return "Por favor seleccione el almacén de gas al que pertenecerá el tanque."
            Case 40
                Return "Por favor escriba la capacidad del tanque."
            Case 41
                Return "La capacidad disponible para este almacen de gas es de: "
            Case 42
                Return "La tripulación no puede ser modificada, solo puede asignarla como titular. ¿Desea hacer el cambio a tripulación titular?."
            Case 43
                Return "Por favor escriba el porcentaje de llenado en que se encuentra la lectura del tanque de gas."
            Case 44
                Return "Por favor seleccione el empleado que tomó la lectura del tanque."
            Case 45
                Return "La cantidad que desea liquidar no es valida ya que excede las existencias."
            Case 46
                Return "Seleccione el tipo de cobro."
            Case 47
                Return "Escriba la cantidad que corresponde al tipo de cobro."
            Case 48
                Return "La liquidación no puede ser completada ya que falta dinero a liquidar."
            Case 49
                Return "No hay comisiones a generar en el periodo de tiempo señalado."
            Case 50
                Return "Falta efectivo para realizar la liquidación"
            Case 51
                Return "No ha introducido ningún producto para realizar la liquidación"
            Case 52
                Return "Por favor escriba el número que asignará al tanque de almacenamiento."
            Case 53
                Return "El número de tanque de almacenamiento que intenta dar de alta ya existe."
            Case 54
                Return "Por favor seleccione la transportadora a la que pertenece el PG."
            Case 55
                Return "Para este tipo de almacén solo puede dar de alta un tanque."
            Case 56
                Return "El porcentaje no es valido."
            Case 57
                Return "La presión no es valida."
            Case 58
                Return "Valor invalido de temperatura."
            Case 59
                Return "Valor invalido de densidad."
            Case 60
                Return "Por favor escriba la descripción del almacén de gas."
            Case 61
                Return "Por favor seleccione el tipo de almacén de gas."
            Case 62
                Return "Por favor seleccione la célula a la que pertenece el almacén de gas."
            Case 63
                Return "Por favor seleccione el camión que pertenece al almacén de gas."
            Case 64
                Return "Por favor seleccione la ruta a la que pertenece el almacén de gas."
            Case 65
                Return "Por favor escriba la capacidad al 100% del almacén de gas."
            Case 66
                Return "La capacidad al 100% no puede ser menor a la capacidad operativa del almacén de gas."
            Case 67
                Return "Por favor agregue la capacidad operativa del almacén de gas."
            Case 68
                Return "¿Está seguro?."
            Case 69
                Return "Por favor seleccione el almacén origen para consultar sus existencias de gas."
            Case 70
                Return "El producto seleccionado no tiene asignado un precio en la fecha seleccionada, no podra realizar la factura."
            Case 71
                Return "El número de folio " & Texto & " ya ha sido registrado, no se pueden duplicar folios."
            Case 72
                Return "La factura de cierre del rango de fechas seleccionadas ya existe."
            Case 73
                Return "El número de embarque tecleado ya existe, porfavor verifique los datos."
            Case 74
                Return "El número de embarque no ha sido pesado, porfavor verifique sus datos."
            Case 75
                Return "El almacén " & Texto & " ya tiene existencias, por lo que no puede asignarle inventario inicial."
            Case 76
                Return "El número de PG " & Texto & " no existe, verifique el número de P.G. de lo contrario será necesario teclear la capacidad."
            Case 77
                Return "La entrada por ducto con folio de factura " & Texto & " ya existe, porfavor verifique su información."
            Case 78
                Return "En la lista de mediciones ya existe una medicion con fecha " & Texto & ", porfavor verifique su información."
            Case 79
                Return "El reporte ya ha sido verificado por el empleado " & Texto & "."
            Case 80
                Return "El reporte ya ha sido aprobado por el empleado " & Texto & "."
            Case 81
                Return "Usuario y clave no correcta, por favor teclee correctamente los datos."
            Case 82
                Return "Para ser aprobado el reporte de inventario físico debe ser verificado antes."
            Case 83
                Return "No es posible cancelar el reporte físico, no ha sido verificado todavia."
            Case 84
                Return "El usuario no cuenta con privilegios para realizar la cancealción."
            Case 85
                Return "No se puede cancelar el movimiento, esta fuera de la fecha permitida, por favor consulte al administrador del sistema."
            Case 86
                Return "No se puede cancelar la carga, ya ha sido liquidada, por favor consulte al administrador del sistema para cancelar la liquidación."
            Case 87
                Return "No se puede realizar el movimiento por que ya ha sido " & Texto & ", verifique la fecha de movimiento."
            Case 88
                Return "El auto tanque '" & Texto & "' tiene un ciclo abierto para venta, debe cerrar el ciclo e intentar nuevamente esta operación."
            Case 89
                Return "El periodo de fechas para la consulta no es correcto, por favor verifiquelo."
            Case 90
                Return "Por favor seleccione el corporativo."
            Case 91
                Return "Por favor seleccione la sucursal."
            Case 92
                Return "Por favor escriba los kilos del programa."
            Case 93
                Return "El PG aun no ha sido destarado, por favor espere a que termine el ciclo de pesado para registrar el embarque."
            Case 94
                Return "Esta opción solo cancela registros de INVENTARIO."
            Case 95
                Return "Por favor teclee el factor de densidad."
            Case 96
                Return "Por favor cheque los porcentajes y los litros totalizador, hay una diferencia fuera de rango entre ambos."
            Case 97
                Return "No existe el número de camión " & Texto & "."
            Case 98
                Return "El inventarios diario del día " & Texto & " ya existe."
            Case 99
                Return "No ha especificado fecha y hora de cierre de inventario, favor de agregarla."
            Case 101
                Return "Ya anexo una medición para este tanque."
            Case 102
                Return "El porcentaje inicial del tanque no puede ser menor que el porcentaje final."
            Case 103
                Return "La presión inicial del tanque no puede ser menor que la presión final."
            Case 104
                Return "La fecha inicial de descarga del tanque no puede ser despues o igual que la fecha final de descarga."
            Case 105
                Return "Por favor seleccione el empleado que tomó la lectura."
            Case 106
                Return "Verifique la fecha y hora de la toma de muestra del hidrómetro."
            Case 107
                Return "La fecha de la muestra del hidrómetro no puede ser despues del inicio de la descarga."
            Case 108
                Return "Por favor agregue las mediciones a los tanques de almacenamiento."
            Case 109
                Return "Por favor introduzca las lecturas de las mediciones correctamente."
            Case 110
                Return "El porcentaje inicial del tanque no puede ser mayor que el porcentaje final."
            Case 111
                Return "La presión inicial del tanque no puede ser mayor que la presión final."
            Case 112
                Return "El movimiento que desea realizar no es un traspado venta filial. Verifique la empresa destino."
            Case 113
                Return "El embarque ya existe. ¿Desea realizar la venta a la empresa filial?."
            Case 114
                Return "¿Realmente desea realizar el corte de inventario del día?."
            Case 115
                Return "Por favor seleccione el tanque de almacenamiento al cuál se le tomaron lecturas físicas."
            Case 116
                Return "Ya existe una medición física de tipo inventario para la fecha especificada."
            Case 117
                Return "El usuario no esta asignado para utilizar el módulo de liquidación portátil."
            Case 118
                Return "El empleado no esta asignado para utilizar el módulo de liquidación portátil."
            Case 119
                Return "La lista de precios no esta actualizada."
            Case 120
                Return "No existe el formato de liquidación o no tiene acceso a la carpeta, intente imprimir más tarde, la información a sido guardada correctamente."
            Case 121
                Return "El cliente no tiene asignado el tipo de cobro: '" + Trim(Texto) + "'."
            Case 122
                Return "La zona económica asignada no corresponde al cliente."
            Case 123
                Return "La sesión de caja no puede ser iniciada."
            Case 124
                Return "No existen clientes en la liquidacion para anexar un pago con cheque a la liquidación."
            Case 125
                Return "La liquidación no se puede realizar debido a que la fecha permitida ya expiró. Consulte al administrador."
            Case 126
                Return "No se puede eliminar el registro porque el cliente tiene pagos asignados con cheque."
            Case 127
                Return "Por favor seleccione el tipo de medidor del cuál se obtuvo el factor de densidad."
            Case 128
                Return "¿Esta seguro de cancelar el registro?"
            Case 129
                Return "La fecha inicial no puede ser despues o igual que la fecha final. Verifique las fechas."
            Case 130
                Return "El folio: " + Trim(Texto) + " ya tiene asignado un movimiento de gas o no existe, favor de corregir."
            Case 131
                Return "No hay pedidos portátil pendientes para realizar cargas."
            Case 132
                Return "El número de sellos debe ser menor o igual a la cantidad de tanques del pedido."
            Case 133
                Return "La informacion debe estar validada."
            Case 134
                Return "El cliente no pertenece al pedido de la carga."
                '20150627CNSM$001-----------------
            Case 135
                Return "La cantidad que desea procesar por pedido por remisión no es válida  ya que excede las existencias."
            Case 136
                Return "No ha introducido ningún producto para realizar el pedido por remisión."
            Case 137
                Return "Es necesario capturar el folio de la remisión Y serie para realizar el pedido por remisión."
            Case 138
                Return "Ya existe el folio de la remisión o la serie."
            Case 139
                Return "La el folio de la remisión debe de ser consecutivo. Ultima folio de la remisión capturado: " & Texto & "."
            Case 140
                Return "Se debe de procesar todo el número de productos existentes."
                '20150627CNSM$001-----------------
                '20161124#LUSATE A SOLICITUD DE TRANSFORMA# INICIO
            Case 141
                Return "La fecha de movimiento, coincide con un acta de cierre con status cerrado. No es posible continuar."
            Case 142
                Return "No es posible cerrar una acta cierre con status CIERRE o CANCELADO."
            Case 143
                Return "No es posible cancelar una acta cierre con status CIERRE o CANCELADO."
            Case 144
                Return "No es posible cerrar una acta cierre sin que esta tenga una medición realizada."
            Case 145
                Return "No es posible realizar una medición con un status CIERRE o CANCELADO."
            Case 146
                Return "¿Esta se guro de cancelar el registro?."
            Case 147
                Return "Ya existe un acta dentro de la fecha especificada. No es posible continuar."
                '20161124#LUSATE A SOLICITUD DE TRANSFORMA# FIN
            Case 148
                '20161226$LUSATE
                Return "Es necesario adjuntar archivo(s) de guía de embarque."
            Case Else
                Return "No hay mensaje."
        End Select
    End Function

    Public Sub New(ByVal NumeroMensaje As Integer)
        Mensaje = Mensajes(NumeroMensaje, "")
    End Sub

    Public Sub New(ByVal NumeroMensaje As Integer, ByVal Texto As String)
        Mensaje = Mensajes(NumeroMensaje, Texto)
    End Sub

End Class
