# BookShopping

Projenin çalışabilmesi için öncelikle veri tabanı ekliyoruz. Visual Studio programında ki menüden Tools > NuGet Package Maneger > Package Manager Console açıyoruz.

Açılan sayfaya login için; "add-migration book -context LoginDbContext" ekliyoruz. (book ismini istediğiniz gibi değiştirebilirsiniz) " update-database -context LoginDbContext" güncelleyerek veri tabanını ekliyoruz.

Kitap alışveriş sayfası  için; "add-migration user -context "ShoppingDbContext" ekliyoruz. (user ismini istediğiniz gibi değiştirebilirsiniz) " update-database -context "ShoppingDbContext" güncelleyerek veri tabanını ekliyoruz.


Şifreyi unuttum ve iletişim sayfaları için; kullanıcı bilgilerini appsettings.Development.json 'den değiştirebilirsiniz.


localhost hatası verdiği durumda;
https://myaccount.google.com/u/2/lesssecureapps linke tıkla ve ardından daha az güvenli uygulamalara izin ver kısmını aç.

F5 veya Debug > Start Debugging tıklayarak projeyi çalıştırıyoruz.
