using CakesLibrary.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;


namespace CakesWpf
{
    public partial class MainWindow : Window
    {
        //ObservableCollection для того чтобы все изменения отображались в интерфейсе
        //без set; чтобы использовалась одна коллекция для ингредиентов
        public ObservableCollection<Ingredient> Ingredients { get; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<string> Recipes { get; } = new ObservableCollection<string>();

        //поля для того чтобы можно было обращаться к складу и кухне из разных методов
        private Storage _storage;
        private Kitchen _kitchen;
        public MainWindow()
        {
            //прорисовка графических элементов
            InitializeComponent();

            //создание и присвоение склада и кухни(объектов)
            _storage = new Storage();
            _kitchen = new Kitchen(_storage);
            _kitchen.CakeReady += _kitchen_CakeReady;

            //связываем код этого файла с кодом xaml
            DataContext = this;

            RefreshIngredients();
            RefreshRecipes();
            
        }

        private void _kitchen_CakeReady(Cake cake)
        {
            MessageBox.Show($"{cake.Name} готов, он стоит {cake.Price} рублей");
            RefreshIngredients();
            RefreshRecipes();
        }
        private void RefreshRecipes()
        {
            Recipes.Clear();
            var recipes = _kitchen.GetAvailableRecipes();
            foreach ( var recipe in recipes.Keys )
            {
                Recipes.Add(recipe);
            }
        }
        private void RefreshIngredients()
        {
            //берем раннее сохраненные ингредиенты и загружаем в свойство Ingredients
            Ingredients.Clear();
            var availableIngredients = _storage.GetAllIngredients();
            foreach (Ingredient ingredient in availableIngredients)
            {
                Ingredients.Add(ingredient);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ingredientName = txtName.Text;
            decimal ingredientCost = decimal.Parse(txtCost.Text);
            int ingredientQuantity = int.Parse(txtQuantity.Text);
            Ingredient ingredient = new Ingredient(ingredientName, ingredientQuantity, ingredientCost);
            _storage.AddIngredients(ingredient);
            RefreshIngredients();
        }

        private void TakeOrder()
        {
            string cakeName = txtCakeName.Text;
            if (string.IsNullOrWhiteSpace(cakeName))
            {
                MessageBox.Show("Цхьа нормальны движени язйе");
                return;
            }

            try
            {
                MessageBox.Show("Готовим, ждите!");
                _kitchen.MakeCake(cakeName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }
        private void btnTakeOrder_Click(object sender, RoutedEventArgs e)
        {
            TakeOrder();
        }
    }
}