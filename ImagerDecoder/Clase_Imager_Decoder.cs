// Decompiled with JetBrains decompiler
// Type: ImagerDecoder.Clase_Imager_Decoder
// Assembly: ImagerDecoder, Version=1.0.3595.20964, Culture=neutral, PublicKeyToken=null
// MVID: 75EE07B4-A3C6-45AF-8BD0-25D3202AFB97
// Assembly location: C:\Documents and Settings\LUSATE\Escritorio\ImagerDecoder.dll

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ImagerDecoder
{
  public class Clase_Imager_Decoder
  {
    public static Image XMLNodeToImage(string strPlantillaArchivoXML, XmlNode Nodo)
    {
      MemoryStream memoryStream = new MemoryStream();
      bool flag = false;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        Cursor.Show();
        StreamWriter streamWriter = new StreamWriter((Stream) memoryStream, Encoding.UTF8);
        streamWriter.Write(Nodo.OuterXml);
        streamWriter.Flush();
        memoryStream.Position = 0L;
        XmlTextReader xmlTextReader = new XmlTextReader((Stream) memoryStream);
        while (xmlTextReader.Read())
        {
          if (xmlTextReader.Name == "Foto")
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          return (Image) null;
        int num = (int) xmlTextReader.MoveToContent();
        xmlTextReader.Read();
        string strImagen = xmlTextReader.ReadString();
        return Clase_Imager_Decoder.String2Image(strPlantillaArchivoXML, strImagen);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return (Image) null;
      }
      finally
      {
        Cursor.Current = Cursors.Default;
        Cursor.Hide();
      }
    }

    public static Image Bytes2Image(byte[] bytes)
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        Cursor.Show();
        if (bytes == null)
          return (Image) null;
        return (Image) new Bitmap((Stream) new MemoryStream(bytes));
      }
      catch
      {
        return (Image) null;
      }
      finally
      {
        Cursor.Current = Cursors.Default;
        Cursor.Hide();
      }
    }

    public static Image String2Image(string strPlantillaArchivoXML, string strImagen)
    {
      DataSet dataSet = new DataSet();
      DataTable dataTable = new DataTable();
      MemoryStream memoryStream = new MemoryStream();
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        Cursor.Show();
        StreamReader streamReader = new StreamReader(strPlantillaArchivoXML, Encoding.UTF8);
        string str = streamReader.ReadToEnd().Replace("<Imagen>", strImagen);
        streamReader.Close();
        StreamWriter streamWriter = new StreamWriter((Stream) memoryStream, Encoding.UTF8);
        streamWriter.Write(str);
        streamWriter.Flush();
        memoryStream.Position = 0L;
        int num = (int) dataSet.ReadXml((Stream) memoryStream);
        dataTable = dataSet.Tables[0];
        if (dataTable != null && dataTable.Rows.Count > 0)
          return Clase_Imager_Decoder.Bytes2Image((byte[]) dataTable.Rows[0][0]);
        return (Image) null;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dataTable != null)
          dataTable.Dispose();
        if (dataSet != null)
          dataSet.Dispose();
        Cursor.Current = Cursors.Default;
        Cursor.Hide();
      }
    }
  }
}
