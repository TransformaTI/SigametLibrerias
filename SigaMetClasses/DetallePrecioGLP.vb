'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''
''  DetallePrecioGLP.vb
''  Implementation of the Class DetallePrecioGLP
''  Generated by Enterprise Architect
''  Created on:      24-abr.-2018 06:08:59 p. m.
''  Original author: Iv�n Trujillo
''  
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''  Modification history:
''  
''
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



Option Explicit On
Option Strict On

Namespace Estructural.Clases.SigaMetClasses
    Public Class DetallePrecioGLP


        Private _ZonaEconomica As Integer
        Private _Precio As Decimal
        Private _PorcentajeIVA As Decimal
        Public m_Precio As Precio

        Public Property ZonaEconomica() As Integer
            Get
                Return _ZonaEconomica
            End Get
            Set(ByVal Value As Integer)
                _ZonaEconomica = Value
            End Set
        End Property

        Public Property Precio() As Decimal
            Get
                Return _Precio
            End Get
            Set(ByVal Value As Decimal)
                _Precio = Value
            End Set
        End Property

        Public Property PorcentajeIVA() As Decimal
            Get
                Return _PorcentajeIVA
            End Get
            Set(ByVal Value As Decimal)
                _PorcentajeIVA = Value
            End Set
        End Property


    End Class ' DetallePrecioGLP

End Namespace ' SigaMetClasses