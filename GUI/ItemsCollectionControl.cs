
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GUI
{
     public class ItemsCollectionControl : Control
    {
        #region ItemSource : object - Элементы коллекции
        public static readonly DependencyProperty ItemSourceProperty =
        DependencyProperty.Register(
           nameof(ItemSource), 
           typeof(object),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(object)));


        public object ItemSource
        {
            get => (object)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
            }

        #endregion

        #region DeleteCommand : ICommand - Комманда удаления объекта

        public static readonly DependencyProperty DeleteCommandProperty =
        DependencyProperty.Register(
           nameof(DeleteCommand),
           typeof(ICommand),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(ICommand)));


        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        #endregion

        #region EditCommand : ICommand - Комманда редактирования объекта

        public static readonly DependencyProperty EditCommandProperty =
        DependencyProperty.Register(
           nameof(EditCommand),
           typeof(ICommand),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(ICommand)));


        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        #endregion

        #region CreateCommand : ICommand - комманда создания объекта

        public static readonly DependencyProperty CreateCommandProperty =
        DependencyProperty.Register(
           nameof(CreateCommand),
           typeof(ICommand),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(ICommand)));


        public ICommand CreateCommand
        {
            get => (ICommand)GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }

        #endregion

        #region PanelName : string - Имя панели

        public static readonly DependencyProperty PanelNameProperty =
        DependencyProperty.Register(
           nameof(PanelName),
           typeof(string),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(string)));


        public string PanelName
        {
            get => (string)GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }

        #endregion
        
        #region SelectionIndex : int - Индекс выбранного элемента

        public static readonly DependencyProperty SelectionIndexProperty =
        DependencyProperty.Register(
           nameof(SelectionIndex),
           typeof(int),
           typeof(ItemsCollectionControl),
           new PropertyMetadata(default(int)));


        public int SelectionIndex
        {
            get => (int)GetValue(SelectionIndexProperty);
            set => SetValue(SelectionIndexProperty, value);
        }

        #endregion

        static ItemsCollectionControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemsCollectionControl), new FrameworkPropertyMetadata(typeof(ItemsCollectionControl)));
        }
    }
}
