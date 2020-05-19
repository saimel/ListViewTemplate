using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewTemplate
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ICommand RemoveContactCommand { get; set; }

        public ObservableCollection<ContactModel> MyContacts { get; set; }

        public MainPage()
        {
            RemoveContactCommand = new Command<ContactModel>(async (ct) => await RemoveContactAsync(ct));
            MyContacts = new ObservableCollection<ContactModel>();
            Populate();

            InitializeComponent();

            BindingContext = this;
        }

        private async Task RemoveContactAsync(ContactModel ct)
        {
            bool response = await DisplayAlert("Remove Contact", string.Format("Do you want to remove '{0}'?", ct.Name), "Yes", "No");
            if(response == true)
            {
                MyContacts.Remove(ct);
            }
        }

        private void Populate()
        {
            var tmp = new List<ContactModel>
            {
                new ContactModel { Name = "Lana Meier", City = "Paris 12", Company = "Dach, Hickle and Bauch" },
                new ContactModel { Name = "Carmon McNelis", City = "Anjia", Company = "Price-Hudson" },
                new ContactModel { Name = "Chester Varran", City = "Netishyn", Company = "Bradtke Group" },
                new ContactModel { Name = "Pernell Bravey", City = "Krasnoarmeysk", Company = "Johns-Schmeler" },
                new ContactModel { Name = "Carolann Winstone", City = "Sollefteå", Company = "Yost, Jakubowski and Wuckert" },
                new ContactModel { Name = "Sherline Woods", City = "Guanba", Company = "Stanton, McGlynn and Sporer" },
                new ContactModel { Name = "Levon Dible", City = "Itacorubi", Company = "Brekke Inc" },
                new ContactModel { Name = "Leann Berriball", City = "Santa Rosa de Copán", Company = "Blanda, Herman and Beer" },
                new ContactModel { Name = "Dalenna March", City = "Xilu", Company = "Haag Group" },
                new ContactModel { Name = "Amalie Truswell", City = "Heling", Company = "Corkery Inc" },
                new ContactModel { Name = "Barbaraanne Keppie", City = "Düsseldorf", Company = "Wiza-Pfeffer" },
                new ContactModel { Name = "Sherilyn Lissett", City = "Kawage", Company = "Waters-Bradtke" },
                new ContactModel { Name = "Mareah Karolyi", City = "Xinyang", Company = "Wiegand-Labadie" },
                new ContactModel { Name = "Jordain Whiston", City = "Altanbulag", Company = "Swaniawski, Cormier and Boyer" },
                new ContactModel { Name = "Caleb Sollitt", City = "Dhuusamarreeb", Company = "Erdman, Stoltenberg and Schuster" },
                new ContactModel { Name = "Cos Rhucroft", City = "Baiyin", Company = "Hoeger-Watsica" },
                new ContactModel { Name = "Petronia Brastead", City = "Kassel", Company = "Halvorson-McLaughlin" },
                new ContactModel { Name = "Shem Willans", City = "Omsk", Company = "Robel-Wiegand" },
                new ContactModel { Name = "Myrilla Howsin", City = "Pergamos", Company = "Mayert-Marks" },
                new ContactModel { Name = "Jenica MacIan", City = "Tulusmulyo", Company = "Schimmel and Sons" },
                new ContactModel { Name = "Leona Rains", City = "San Clemente", Company = "Runolfsdottir-Monahan" },
                new ContactModel { Name = "Paloma Denes", City = "Siwa Oasis", Company = "Legros, Daugherty and Lebsack" },
                new ContactModel { Name = "Marve Voules", City = "Librazhd-Qendër", Company = "Howe, Wisozk and Schamberger" },
                new ContactModel { Name = "Farr Dowbakin", City = "Kubangkondanglapangan", Company = "Sanford-Bogisich" },
                new ContactModel { Name = "Norman Bohan", City = "Mungo", Company = "Johns, Gerhold and Windler" },
                new ContactModel { Name = "Anya Haverty", City = "Chotepe", Company = "O'Conner, Bosco and Feest" },
                new ContactModel { Name = "Freda Schutze", City = "Tomaszów Mazowiecki", Company = "Johnson Group" },
                new ContactModel { Name = "Brandais Costa", City = "Tengah", Company = "Stamm-McLaughlin" },
                new ContactModel { Name = "Silvan Yendall", City = "Khasavyurt", Company = "Watsica LLC" },
                new ContactModel { Name = "Perkin Wroughton", City = "Tumba", Company = "Halvorson Group" },
                new ContactModel { Name = "Vernen McVane", City = "Sauga", Company = "Kling LLC" },
                new ContactModel { Name = "Missy Cashman", City = "Ampara", Company = "Borer, Price and Lubowitz" },
                new ContactModel { Name = "Lewie Leversha", City = "Carvalho", Company = "Gutkowski LLC" },
                new ContactModel { Name = "Tine Kipling", City = "Soufrière", Company = "Reynolds LLC" },
                new ContactModel { Name = "Belinda Pentelow", City = "Sumbersarikrajan", Company = "Wehner Inc" },
                new ContactModel { Name = "Johnny Longstaff", City = "Donggu", Company = "Cronin Inc" },
                new ContactModel { Name = "Athene Bowditch", City = "Neob", Company = "Gutmann, O'Conner and Schowalter" },
                new ContactModel { Name = "Gail Tasseler", City = "Keli", Company = "Herman, Barrows and Upton" },
                new ContactModel { Name = "Mellisa Northwood", City = "Vovchans’k", Company = "Brekke-Hermann" },
                new ContactModel { Name = "Anthiathia Mattei", City = "Wucheng", Company = "Batz-O'Hara" },
                new ContactModel { Name = "Harper McRitchie", City = "Barkol", Company = "Greenholt-Feeney" },
                new ContactModel { Name = "Evelyn Dory", City = "Linggamanik", Company = "Rowe Group" },
                new ContactModel { Name = "Brendon Raymen", City = "Bolo", Company = "Greenholt, Kassulke and Jenkins" },
                new ContactModel { Name = "Leeanne Howley", City = "Gary", Company = "Gutkowski-Luettgen" },
                new ContactModel { Name = "Elden Riggott", City = "Čajniče", Company = "Runte-Bednar" },
                new ContactModel { Name = "Modesty Michelin", City = "Muyuzi", Company = "Roob Inc" },
                new ContactModel { Name = "Pauly Stephens", City = "Pagsabangan", Company = "Cartwright-Dickinson" },
                new ContactModel { Name = "Kittie Caldayrou", City = "Kissimmee", Company = "Bode-Fritsch" },
                new ContactModel { Name = "Alfi Wythe", City = "Yauca", Company = "Hills-O'Keefe" },
                new ContactModel { Name = "Robin Brommage", City = "Xuefu", Company = "Olson, Abernathy and Ratke" },
                new ContactModel { Name = "Mariana Kapiloff", City = "Krajan Satu", Company = "Homenick, Johns and Schmidt" },
                new ContactModel { Name = "Thaine Carnock", City = "Visby", Company = "Marks and Sons" },
                new ContactModel { Name = "Conni Pool", City = "Karmah an Nuzul", Company = "Robel, Davis and Barrows" },
                new ContactModel { Name = "Carrissa Keneleyside", City = "Vahdat", Company = "Pacocha, Gerlach and Senger" },
                new ContactModel { Name = "Lotta Salisbury", City = "Diapaga", Company = "Swaniawski, Rippin and Kautzer" },
                new ContactModel { Name = "Claude Saffe", City = "Uthai Thani", Company = "Gaylord Group" },
                new ContactModel { Name = "Tina Yitzhok", City = "Guanagazapa", Company = "Dickinson, Keebler and Lehner" },
                new ContactModel { Name = "Missie Gazey", City = "Zaplavnoye", Company = "Schiller LLC" },
                new ContactModel { Name = "Ardith Maghull", City = "Askaniya Nova", Company = "Mann LLC" },
                new ContactModel { Name = "Felice Solomon", City = "Lillooet", Company = "Gaylord, Abshire and Greenholt" },
                new ContactModel { Name = "Lyon Lippard", City = "Vondrozo", Company = "Gislason, Dickinson and Bechtelar" },
                new ContactModel { Name = "Shannen Crebott", City = "Shiyu", Company = "Pagac Inc" },
                new ContactModel { Name = "Jody Heinreich", City = "Mucifal", Company = "Kirlin and Sons" },
                new ContactModel { Name = "Abdul Crewe", City = "Mintang", Company = "Leannon-Shanahan" },
                new ContactModel { Name = "Anabal Warcop", City = "Bīrganj", Company = "Wolff-Russel" },
                new ContactModel { Name = "Tracy Nesfield", City = "Kampungdesa", Company = "Kassulke LLC" },
                new ContactModel { Name = "Mitch Cockill", City = "Mangaldan", Company = "Cummerata Inc" },
                new ContactModel { Name = "Meta Froggatt", City = "Warri", Company = "Pfeffer-Bosco" },
                new ContactModel { Name = "Padget Brixey", City = "Usman’", Company = "Kshlerin-Roberts" },
                new ContactModel { Name = "Antoine Fowley", City = "Plei Kần", Company = "McClure-Abernathy" },
                new ContactModel { Name = "Nappie Tolan", City = "Indang", Company = "Kub Inc" },
                new ContactModel { Name = "Lothario Curme", City = "Roscoff", Company = "Oberbrunner, Dicki and O'Kon" },
                new ContactModel { Name = "Karlotta Snowden", City = "Matriz de Camaragibe", Company = "Morissette, Kovacek and Wiza" },
                new ContactModel { Name = "Liza Mosdill", City = "Butwāl", Company = "Cartwright, Rogahn and Quigley" },
                new ContactModel { Name = "Matti Parmiter", City = "Filiatrá", Company = "Emmerich and Sons" },
                new ContactModel { Name = "Gayelord Londer", City = "Oke Mesi", Company = "Lockman-Konopelski" },
                new ContactModel { Name = "Arnie Cotillard", City = "Hornówek", Company = "Bernhard, Lemke and Walker" },
                new ContactModel { Name = "Madeleine Syratt", City = "Lirang", Company = "Gleason Inc" },
                new ContactModel { Name = "Orland Boundley", City = "Trondheim", Company = "Schimmel-Kilback" },
                new ContactModel { Name = "Carey Brugden", City = "Tenancingo", Company = "Lemke and Sons" },
                new ContactModel { Name = "Sher Mantle", City = "Vạn Giã", Company = "Dooley and Sons" },
                new ContactModel { Name = "Fifine Cerith", City = "Légua", Company = "Waelchi, Labadie and Schuppe" },
                new ContactModel { Name = "Biddie Gurnee", City = "Garunggang", Company = "Zieme Inc" },
                new ContactModel { Name = "Sammy Garritley", City = "Qamdo", Company = "Bruen-Hoppe" },
                new ContactModel { Name = "Burch Crossley", City = "Pinggan", Company = "Huels-Cronin" },
                new ContactModel { Name = "Sanford Taylder", City = "Revolucion Verde", Company = "Blanda, Hauck and Prosacco" },
                new ContactModel { Name = "Brendin Mell", City = "Xinqiao", Company = "Wintheiser, Keebler and Heller" },
                new ContactModel { Name = "Odetta Teml", City = "Tunbao", Company = "Brown LLC" },
                new ContactModel { Name = "Claudette Kamena", City = "Bolesławiec", Company = "Sporer-Dietrich" },
                new ContactModel { Name = "Rosalinda Toon", City = "Bhunya", Company = "Koepp, Wyman and Braun" },
                new ContactModel { Name = "Godwin Insworth", City = "Kolbano", Company = "Skiles, Harber and Ferry" },
                new ContactModel { Name = "Deeyn Tomney", City = "Nanlin", Company = "Stamm, Kozey and Gusikowski" },
                new ContactModel { Name = "Clerissa Ceresa", City = "Amnat Charoen", Company = "Dicki, Rodriguez and McKenzie" },
                new ContactModel { Name = "Franky Halbert", City = "Cherëmukhovo", Company = "Goyette, Nolan and Kuvalis" },
                new ContactModel { Name = "Ashely Gladstone", City = "Baiyang", Company = "Schroeder-Kutch" },
                new ContactModel { Name = "Davida Kilgannon", City = "Yurovka", Company = "Purdy LLC" },
                new ContactModel { Name = "Penrod Croose", City = "Malainen Luma", Company = "Hammes-Smith" },
                new ContactModel { Name = "Kath Gourley", City = "Baras", Company = "Larson and Sons" },
                new ContactModel { Name = "Vito Neesham", City = "Bluri", Company = "Mraz Group" },
                new ContactModel { Name = "Elaina Scay", City = "Taurisma", Company = "Kreiger, Marks and Funk" }
            };

            foreach (var ct in tmp.OrderBy(c => c.Name))
            {
                MyContacts.Add(ct);
            }
        }
    }
}
