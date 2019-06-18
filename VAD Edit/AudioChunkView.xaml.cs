﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VADEdit
{
    /// <summary>
    /// Interaction logic for AudioChunkView.xaml
    /// </summary>
    public partial class AudioChunkView : UserControl
    {
        private static event EventHandler StaticFocused;
        public event EventHandler PlayButtonClicked;
        public event EventHandler SttButtonClicked;
        public event EventHandler ExportButtonClicked;
        public event EventHandler DeleteButtonClicked;
        public event EventHandler StopButtonClicked;
        public event EventHandler GotSelectionFocus;


        public Visibility PlayButtonVisibility
        {
            get { return (Visibility)GetValue(PlayButtonVisibilityProperty); }
            set { SetValue(PlayButtonVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayButtonVisibilityProperty =
            DependencyProperty.Register("PlayButtonVisibility", typeof(Visibility), typeof(AudioChunkView), new PropertyMetadata(Visibility.Visible));


        public TimeRange TimeRange
        {
            get { return (TimeRange)GetValue(TimeRangeProperty); }
            set { SetValue(TimeRangeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeRange.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeRangeProperty =
            DependencyProperty.Register("TimeRange", typeof(TimeRange), typeof(AudioChunkView), new PropertyMetadata(null));


        public string SpeechText
        {
            get { return (string)GetValue(SpeechTextProperty); }
            set { SetValue(SpeechTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpeechText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpeechTextProperty =
            DependencyProperty.Register("SpeechText", typeof(string), typeof(AudioChunkView), new PropertyMetadata(null));


        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(AudioChunkView), new PropertyMetadata(false));

        public AudioChunkView()
        {
            InitializeComponent();
            StaticFocused += delegate
            {
                Background = Brushes.White;
            };
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonClicked?.Invoke(this, e);
        }

        private void btnStt_Click(object sender, RoutedEventArgs e)
        {
            SttButtonClicked?.Invoke(this, e);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            ExportButtonClicked?.Invoke(this, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            StaticFocused?.Invoke(this, EventArgs.Empty);
            Background = SystemColors.MenuHighlightBrush;
            GotSelectionFocus?.Invoke(this, EventArgs.Empty);
        }

        private void txtSpeech_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSpeech.Text))
                txtSpeech.ToolTip = null;
            else
                txtSpeech.ToolTip = txtSpeech.Text;
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            txtSpeech.Focus();
            base.OnPreviewMouseLeftButtonDown(e);
        }
    }

    public class NegateVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Visibility)value == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
