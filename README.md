# BookShopping

Projenin çalışabilmesi için öncelikle veri tabanı ekliyoruz. Visual Studio programında ki menüden Tools > NuGet Package Maneger > Package Manager Console açıyoruz.

Açılan sayfaya login için; "add-migration book -context LoginDbContext" ekliyoruz. (book ismini istediğiniz gibi değiştirebilirsiniz) " update-database -context LoginDbContext" güncelleyerek veri tabanını ekliyoruz.

Kitap alışveriş sayfası  için; "add-migration user -context "ShoppingDbContext" ekliyoruz. (user ismini istediğiniz gibi değiştirebilirsiniz) " update-database -context "ShoppingDbContext" güncelleyerek veri tabanını ekliyoruz.


Şifreyi unuttum ve iletişim sayfaları için; kullanıcı bilgilerini appsettings.Development.json dosyasından değiştirebilirsiniz.
