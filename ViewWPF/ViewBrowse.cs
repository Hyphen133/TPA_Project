﻿using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using ViewModel;

namespace ViewWPF
{
    class ViewBrowse : IBrowse
    {
        public string GetFilePath()
        {
            OpenFileDialog test = new OpenFileDialog();
            test.ShowDialog();
            return test.FileName;
        }

        public string GetFolderPath()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
                return dialog.FileName;
            }
            else
            {
                return GetFolderPath();
            }
        }
    }
}
