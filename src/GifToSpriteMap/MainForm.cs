using System;
using System.Linq ;
using System.Windows.Forms;

namespace GifToSpriteMap
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			Application.ThreadException += applicationThreadException;
			InitializeComponent();
		}

		static void applicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
			Application.Exit();
		}

		private void form1Load(object sender, EventArgs e)
		{
			comboBoxShape.SelectedIndex = 0;
			
			uiComboOutputAs.Items.AddRange( Enum.GetNames( typeof(OutputFormat )) );
			uiComboOutputAs.SelectedItem = OutputFormat.Dds.ToString( ) ;

			
			updateButtons();
		}

		private void buttonAddClick(object sender, EventArgs e)
		{
			var openFileDialog = new OpenFileDialog
			                     	{
			                     		Filter = @"Animated gifs (*.gif)|*.gif|All files (*.*)|*.*",
			                     		Multiselect = true
			                     	} ;
			
			DialogResult dr = openFileDialog.ShowDialog();
			if (dr != DialogResult.OK)
			{
				return;
			}

			foreach (string s in openFileDialog.FileNames)
			{
				listBoxPaths.Items.Add(s);
			}

			updateButtons();
		}

		private void buttonGoClick(object sender, EventArgs e)
		{
			var destinationShape = (DestinationShape)Enum.Parse(typeof(DestinationShape), comboBoxShape.Text);
			var outputFormat = (OutputFormat)Enum.Parse(typeof(OutputFormat), uiComboOutputAs.Text);
			
			var paths = new string[listBoxPaths.Items.Count];
			
			int i = 0;
			
			foreach (string s in listBoxPaths.Items)
			{
				paths[i++] = s;
			}
			
			var processingWindow = new ProcessingWindow(paths, destinationShape, outputFormat);

			processingWindow.ShowDialog(this);
		}

		void buttonMoveDownClick(object sender, EventArgs e)
		{
			int n = listBoxPaths.SelectedIndex;
			object o = listBoxPaths.Items[n];
			listBoxPaths.Items.RemoveAt(n);
			++n;
			n = Math.Min(listBoxPaths.Items.Count, n);
			listBoxPaths.Items.Insert(n, o);
			listBoxPaths.SelectedIndex = n;
		}

		void updateButtons()
		{
			buttonRemove.Enabled = listBoxPaths.SelectedItems.Count > 0;

			int count = listBoxPaths.SelectedItems.Count;
			int index = listBoxPaths.SelectedIndex;
			buttonMoveUp.Enabled = count == 1 && index > 0;
			buttonMoveDown.Enabled = count == 1 && index < listBoxPaths.Items.Count - 1;
			buttonGo.Enabled = listBoxPaths.Items.Count > 0;
		}

		private void listBoxPathsSelectedIndexChanged(object sender, EventArgs e)
		{
			updateButtons();
		}

		private void buttonRemoveClick(object sender, EventArgs e)
		{
			var selectedIndex = listBoxPaths.SelectedIndex;
			
			var paths = listBoxPaths.SelectedItems.Cast<string>( ).ToList( ) ;

			foreach (string s in paths)
			{
				listBoxPaths.Items.Remove(s);
			}

			if (listBoxPaths.Items.Count > 0)
			{
				listBoxPaths.SelectedIndex = Math.Min(listBoxPaths.Items.Count - 1, selectedIndex);
			}

			updateButtons();
		}

		private void buttonMoveUpClick(object sender, EventArgs e)
		{
			int n = listBoxPaths.SelectedIndex;
			object o = listBoxPaths.Items[n];
			listBoxPaths.Items.RemoveAt(n);
			--n;
			n = Math.Max(0, n);
			listBoxPaths.Items.Insert(n, o);
			listBoxPaths.SelectedIndex = n;
		}

		void uiComboOutputAsSelectedIndexChanged(object sender, EventArgs e)
		{
			bool isDdsFormat = uiComboOutputAs.Text == OutputFormat.Dds.ToString( ) ;
			comboBoxShape.Enabled = !isDdsFormat ;
		}
	}
}