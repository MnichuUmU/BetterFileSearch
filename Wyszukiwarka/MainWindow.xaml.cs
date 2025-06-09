using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace Wyszukiwarka
{


    public partial class MainWindow : Window
    {
        class FindAndSaveDir
        {
            private List<string> CFilePath;
            private List<string> CFileName;
            private List<string> CFileExtention;

            public FindAndSaveDir()
            {
                CFilePath = new List<string>();
                CFileName = new List<string>();
                CFileExtention = new List<string>();
            }

            public (List<string>, List<string>, List<string>) FindDataMethod(string DirPath, string SearchByText, string SearchByExtention)
            {
                string path1 = DirPath.Trim();
                string findText = SearchByText.Trim();
                string findExtention = SearchByExtention.Trim();
                
                

                try
                {

                    //MessageBox.Show("Try Beggins");
                    DirectoryInfo dir = new DirectoryInfo(@path1);
                    if (dir.Exists)
                    {
                        //MessageBox.Show("Exists");
                        string[] files = Directory.GetFiles(path1);

                        foreach (var item in files)
                        {
                            if (item.Split('.')[0].Contains(findText) && item.EndsWith(findExtention))
                            {
                               
                                string[] tempE = item.Split('.');
                                string temp1 = tempE[tempE.Length - 1];
                                CFileExtention.Add(temp1);
                                //MessageBox.Show(temp1);
                                

                                string[] tempN = item.Split('\\');
                                temp1 = tempN[tempN.Length - 1];
                                CFileName.Add(temp1);
                                //MessageBox.Show(temp1);

                                CFilePath.Add(item);
                                //MessageBox.Show(item);
                            }

                        }
                        //MessageBox.Show("foreach file has been left");
                        string[] IsDir = Directory.GetDirectories(path1);
                        foreach (string subdir in IsDir)
                        {
                            //MessageBox.Show(subdir);
                            FindDataMethod(subdir, findText, SearchByExtention);
                        }
                        //MessageBox.Show("the right return returns and we exit the method");
                        return (CFilePath, CFileName, CFileExtention);
                    }
                    else
                    {
                        MessageBox.Show("Path does not exist");
                        return (CFilePath, CFileName, CFileExtention);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return (CFilePath, CFileName, CFileExtention);
                }

            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fun_OpenFile(string Path)
        {
            Process.Start("explorer.exe", @Path);
        }
        private void Fun_OpenFileMenager(string Path, string Name)
        {
            string a = Path.Replace(Name, "");
            Process.Start("explorer.exe", @a);
        }
        private void Fun_CopyPath(string Path)
        {
            Clipboard.SetText(Path);
            MessageBox.Show($"{Path} zostało skopiowane do schowka!");
        }
        private async void btnFind_Click(object sender, RoutedEventArgs e)
        {
            lblLoadning.Content = "Ładowanie..";
            lblLoadning.Foreground = Brushes.Blue;
            ViewFiles.Children.Clear();

            //////////////////////////
            /// Kułeczko nie działa :(

            //bool IsDone = false;


            /*await Task.Run(() => 
            {
                Image loadingCircle = new ImageAwesome
                {
                    Icon = FontAwesomeIcon.Cog,
                    Spin = true,
                    Width = 32,
                    Height = 32,
                    Foreground = Brushes.White
                };
                Grid.SetColumn(loadingCircle, 3);

                GridUI.Children.Add(loadingCircle);

                if (IsDone) {
                    GridUI.Children.Remove(loadingCircle);
                }

            });*/

            //////////////////////////

            var Dane = new FindAndSaveDir();
            var (FPath, FName, FExtention) = Dane.FindDataMethod(tbxPath.Text, tbxSName.Text, tbxSEntention.Text);


            lblLoadedCount.Content = "Załadowano: " + FPath.Count.ToString();

            

            for (int i = 0; i < FPath.Count; i++)
            {
                string path = FPath[i];       
                string name = FName[i];

                


                //MessageBox.Show(i.ToString());
                ViewFiles.RowDefinitions.Add(new RowDefinition { });

                var GridLeft = new Grid { Background = new SolidColorBrush(Color.FromRgb(56, 56, 56)), };
                Grid.SetRow(GridLeft, i);
                Grid.SetColumn(GridLeft, 0);

                GridLeft.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                GridLeft.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8, GridUnitType.Star) });
                GridLeft.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
                GridLeft.RowDefinitions.Add(new RowDefinition { });

                var GridRight = new Grid { Background = new SolidColorBrush(Color.FromRgb(56, 56, 56)), };
                Grid.SetRow(GridRight, i);
                Grid.SetColumn(GridRight, 1);

                GridRight.ColumnDefinitions.Add(new ColumnDefinition { });
                GridRight.ColumnDefinitions.Add(new ColumnDefinition { });
                GridRight.ColumnDefinitions.Add(new ColumnDefinition { });
                GridRight.RowDefinitions.Add(new RowDefinition { });


                var lblId = new Label
                {
                    Content = (i+1).ToString(),
                    Margin = new Thickness(5),
                    Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
                };
                Grid.SetRow(lblId, 0);
                Grid.SetColumn(lblId, 0);

                var lblName = new Label
                {
                    Content = name,
                    Margin = new Thickness(1, 5, 1, 5),
                    Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                };
                Grid.SetRow(lblName, 0);
                Grid.SetColumn(lblName, 1);

                var lblExtention = new Label
                {
                    Content = FExtention[i],
                    Margin = new Thickness(1, 5, 1, 5),
                    Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                    
                };
                Grid.SetRow(lblExtention, 0);
                Grid.SetColumn(lblExtention, 2);

                var btnCopyPath = new Button
                {
                    Content = "Skopiuj ściezke",
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5),


                };
                btnCopyPath.Click += (send, args) => Fun_CopyPath(path);
                Grid.SetRow(btnCopyPath, 0);
                Grid.SetColumn(btnCopyPath, 0);

                var OpenFileMenager = new Button
                {
                    Content = "Otwórz Explorator",
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5)
                };
                OpenFileMenager.Click += (send, args) => Fun_OpenFileMenager(path, name);
                Grid.SetRow(OpenFileMenager, 0);
                Grid.SetColumn(OpenFileMenager, 1);

                var OpenFile = new Button
                {
                    Content = "Otwórz plik",
                    Width = 100,
                    Height = 20,
                    Margin = new Thickness(5)
                };
                OpenFile.Click += (send, args) => Fun_OpenFile(path);
                Grid.SetRow(OpenFile, 0);
                Grid.SetColumn(OpenFile, 2);

               



                GridLeft.Children.Add(lblId);
                GridLeft.Children.Add(lblName);
                GridLeft.Children.Add(lblExtention);

                GridRight.Children.Add(btnCopyPath);
                GridRight.Children.Add(OpenFileMenager);
                GridRight.Children.Add(OpenFile);

                ViewFiles.Children.Add(GridLeft);
                ViewFiles.Children.Add(GridRight);
            }
            lblLoadning.Content = "Załadowano :3";
            lblLoadning.Foreground = Brushes.Green;
            //IsDone = true;
        }

        private void btnChooseDir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                tbxPath.Text = openFileDlg.SelectedPath;
            }

        }
    }

}





