// Decompiled with JetBrains decompiler
// Type: admEdificiosComisionAdm.global
// Assembly: admEdificiosComisionAdm, Version=1.0.3562.31791, Culture=neutral, PublicKeyToken=null
// MVID: F73F3EDC-429A-4AAE-8918-12B1EE44C416
// Assembly location: C:\Users\ostech\Desktop\Descomp\admEdificiosComisionAdm.dll

using System.Data.SqlClient;

namespace admEdificiosComisionAdm
{
  public class global
  {
    private static void Main()
    {
      int num = (int) new Captura(502317813, new SqlConnection("data source=192.168.1.15;initial catalog=Reportes;integrated security=SSPI;")).ShowDialog();
    }
  }
}
