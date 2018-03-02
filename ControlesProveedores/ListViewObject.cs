using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Data;

namespace GasMetropolitano.Controls
{
 public delegate bool ValidatorDelegate(string someValue);

   public class ListViewObject:ListView
    {
	   
	   private bool _isValid=true;
	   private object _object;
	   private DataTable _dtLengths = new DataTable();


	   private ValidatorDelegate [] _validatorDelegate;
	   public 	ValidatorDelegate [] ValidatorMethods
	   {
		   set 
		   {
				_validatorDelegate=value;
		   }
	   }

	   public ListViewObject()
        { 
           this.FullRowSelect = true; 
        }

       private   string [] GetObjectValues(object o)
        {
			Graphics grp =this.CreateGraphics();
            string [] values= new string[o.GetType().GetProperties().Length];
            object[]lengths= new object[o.GetType().GetProperties().Length];
			int i = 0;
            foreach (PropertyInfo property in o.GetType().GetProperties())
            {
                values[i] = o.GetType().InvokeMember(property.Name, System.Reflection.BindingFlags.GetProperty, null, o, null).ToString().Trim();
				lengths[i]= Convert.ToInt32(grp.MeasureString(values[i].ToString().Trim(), this.Font).Width);

				if ((_autoValidateColumn)&& (_isValid))
					_isValid=this._validatorDelegate[i](values[i]);
				i++;
            }
			_dtLengths.Rows.Add(lengths);
            return values;
        }

	   public ArrayList GetCheckedItems()
	   {
		   ArrayList checkedItems = new ArrayList();
		   foreach(ListViewItem item in this.Items)
			   if (item.Checked)
				   checkedItems.Add((object)item.Tag);
		   return checkedItems;
	   }

	   public ArrayList GetAllItems()
	   {
		   ArrayList checkedItems = new ArrayList();
		   foreach(ListViewItem item in this.Items)
			   checkedItems.Add((object)item.Tag);
		   return checkedItems;
	   }



        private  void GenerateColumns(object o)
        {
			if (this.Columns.Count == 0)
            {	
                foreach (PropertyInfo property in o.GetType().GetProperties())
                {
                    this.Columns.Add(property.Name,100,System.Windows.Forms.HorizontalAlignment.Left);
                }
            }
			
			
        }
	    private void InitDTLengths(object o)
	   {
		   this._object=o;
		   this._dtLengths.Clear();
		   this._dtLengths.Columns.Clear();
		   this._dtLengths.Rows.Clear();
		   if (o.GetType().GetProperties().Length>0)
			   foreach (PropertyInfo property in o.GetType().GetProperties())
				   this._dtLengths.Columns.Add(property.Name,typeof(int));
	   }


		public void InsertObject(object o)
		{	
			
			if (this.Items.Count==0)
				this.InitDTLengths(o);

			if (this.Columns.Count==0)
				this.GenerateColumns(o);
			ListViewItem item = new ListViewItem(this.GetObjectValues(o));
			item.Tag = o;
			this.Items.Add(item);
			this.View = View.Details;
		}

        public void AddRangeObjects(ArrayList list)
		{
			if (list.Count>0)
				InitDTLengths((object)list[0]);

			if ((this.Columns.Count==0)&&(list.Count>0))
				this.GenerateColumns((object)list[0]);

			ListViewItem item;
			foreach (Object o in list)
			{
				_isValid=true;
				item = new ListViewItem(this.GetObjectValues(o));
				item.Tag = o;
				if (!_isValid)
					item.BackColor=Color.Red;
				this.Items.Add(item);
			}
			this.View = View.Details;
        }

        public object GetCurrentSelectedObject()
        {
            if (this.SelectedItems.Count != 0)
                return (object)this.SelectedItems[0].Tag;
            else
                return null;
        }

        public object[] GetCurrentSelectedObjects()
        {
            object[] objects = new object[this.SelectedItems.Count];
            if (this.SelectedItems.Count != 0)
            {
                for (int i = 0; i < this.SelectedItems.Count;i++ )
                    objects[i] = (object)this.SelectedItems[i].Tag;
                return objects;
            }
            else
                return null;
        }

		public ArrayList GetArrayListCurrentSelectedObjects()
		{
			ArrayList array = new ArrayList();
			if (this.SelectedItems.Count != 0)
			{
				foreach(ListViewItem item in this.SelectedItems )
					array.Add( (object)item.Tag);
				return array;
			}
			else
				return null;
		}



	   private bool _autoValidateColumn=false;
	   public bool AutoValidateColumn
	   {
		   get {return _autoValidateColumn;}
		   set {_autoValidateColumn=value;}
	   }

	   public  void columnResize()
	   {
		   if (this.Columns.Count>0)
		   {
			   Graphics grp =this.CreateGraphics();
			   int width=0;
			   int i=0;
			   foreach (PropertyInfo property in this._object.GetType().GetProperties())
			   {
				   width= Convert.ToInt32(this._dtLengths.Compute( "MAX(" + property.Name +")",null).ToString());
				   if (width < Convert.ToInt32(grp.MeasureString(this.Columns[i].Text.Trim(), this.Font).Width))
					   this.Columns[i].Width=Convert.ToInt32(grp.MeasureString(this.Columns[i].Text.Trim(), this.Font).Width)+10;
				   else
					   this.Columns[i].Width=width + 10;
				   i++;
			   }

		   }

//		   Graphics grp =this.CreateGraphics();
//		   for(int i=0;i<this.Columns.Count;i++)
//		   {
//			   int width=0;
//			   foreach (ListViewItem item in  this.Items)
//			   { 
//				   if (width < Convert.ToInt32(grp.MeasureString(item.SubItems[i].Text.Trim(), this.Font).Width))
//					   width = Convert.ToInt32(grp.MeasureString(item.SubItems[i].Text.Trim(), this.Font).Width);
//			   }
//			   
//			   if (width < Convert.ToInt32(grp.MeasureString(this.Columns[i].Text.Trim(), this.Font).Width))
//				   this.Columns[i].Width=Convert.ToInt32(grp.MeasureString(this.Columns[i].Text.Trim(), this.Font).Width)+10;
//			   else
//				   this.Columns[i].Width=width + 10;
//		   }
	   }

    }
}
