// Decompiled with JetBrains decompiler
// Type: EDFAsignacionDataLayer.LecturistaZonaEdificio
// Assembly: EDFAsignacionDataLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 54098768-E692-413E-A2E5-81417BF5BEB6
// Assembly location: C:\Videos\EDFAsignacionDataLayer.dll

using System;

namespace EDFAsignacionDataLayer
{
  public class LecturistaZonaEdificio
  {
    private short _año;
    private short _consecutivo;
    private DateTime _fVigenciaA;
    private DateTime _fVigenciaB;
    private string _usuarioAsignacion;
    private DateTime _fAltaAsignacion;
    private Lecturista _lecturista;
    private ZonaEdificio _zonaEdificio;

    public LecturistaZonaEdificio(short Lecturista, byte ZonaEdificio, DateTime FVigenciaA, DateTime FVigenciaB, string UsuarioAsignacion)
    {
    }

    public LecturistaZonaEdificio(short Lecturista, short Año, short Consecutivo)
    {
    }

    public bool ModificarLecturistaZonaEdificio()
    {
      return true;
    }
  }
}
