using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;

namespace Prodma.DataAccessB2C.Ortak_Classlar
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomEdit : RepositoryItemCheckedComboBoxEdit
    {

        static RepositoryItemCustomEdit() { RegisterCustomEdit(); }

        public RepositoryItemCustomEdit() { }

        public const string CustomEditName = "CustomEdit";
        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            Image img = null;
            try
            {
                img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                  GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
            }
            catch
            {
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomEdit), typeof(RepositoryItemCustomEdit),
              typeof(PopupContainerEditViewInfo), new ButtonEditPainter(), true, img));
        }

        bool incrementalSearch = false;

        public bool IncrementalSearch
        {
            get { return incrementalSearch; }
            set
            {
                if (incrementalSearch != value)
                    incrementalSearch = value;
            }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemCustomEdit source = item as RepositoryItemCustomEdit;
                if (source == null) return;
                incrementalSearch = source.IncrementalSearch;
            }
            finally
            {
                EndUpdate();
            }
        }
    }


    public class CustomEdit : CheckedComboBoxEdit
    {

        static CustomEdit() { RepositoryItemCustomEdit.RegisterCustomEdit(); }

        public CustomEdit() { }

        public override string EditorTypeName
        {
            get
            {
                return
RepositoryItemCustomEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomEdit; }
        }

        protected override PopupContainerControl CreatePopupCheckListControl()
        {
            PopupContainerControl popupControl = base.CreatePopupCheckListControl();
            CheckedListBoxControl listBox = popupControl.Controls[0] as CheckedListBoxControl;
            listBox.IncrementalSearch = Properties.IncrementalSearch;
            listBox.KeyDown += OnListBoxKeyDown;
            return popupControl;
        }

        void OnListBoxKeyDown(object sender, KeyEventArgs e)
        {
            CheckedListBoxControl listBox = sender as CheckedListBoxControl;
            if (e.KeyData == Keys.Space && Properties.IncrementalSearch)
            {
                listBox.ToggleItem(listBox.SelectedIndex);
                e.Handled = true;
            }
        }

    }
}
