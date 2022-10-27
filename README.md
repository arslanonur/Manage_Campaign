

# Kampanya Yönetimi

Bu proje aşağıdaki caseler göz önüne alınarak oluşturulmuş bir API projesidir.


Domainde kampanyalarınız olacaktır ve bu kampanyaların sepetten gelen ürünlere göre hesaplanıp hesaplanıp cevap olarak sepetteki ürünleri 
 varsa kampanya bilgisi ve indirim bilgisiyle dönülmelidir.

- Kampanyalar, belirli bir ürün grubuna, belirli bir markaya, belirli bir kategoriye veya belirli bir ürün koduna göre tanımlanabilir. 
  Ürünler birden fazla ürün grubunda yer alabilir.

- Kampanyalar belirli bir isme, başlangıç tarihine ve bitiş tarihine sahip olmalıdır ve gerektiğinde pasif e alınabilir olmalıdır.

- Kampanyaları belirli bir sepet tutarına göre çalıştırılabilir olmalıdır.

- Kampanyalar belirli bir oran indirimine veya belirli bir fiyat indirimine göre iki tipte tanımlanabilir
  ve indirimler ürünlere eşit dağıtılmalıdır.

- Kampanyalar hesaplanırken kullanıcıya en fazla indirimi veren kampanya hesaplanmalı ve response da o kampanya 
  dönülmelidir. Kampanyalar ürünlerin fiyatlarına göre oranlanmalı ve buna göre indirim dağıtılmalıdır.
  Sepette sadece bir kampanya çalışmalıdır.

## Veri Tasarımı
Uygulamada Product, Campaign ve Basket isimli 3 tablo kullanılmıştır. Code-First olarak yazılan uygulamada tablolara uygulama ayağa kalkınca create olacaktır. 

## Uygulamayı Çalıştırma
1. "appsettings.json" dosyası üzerinden DataConnectionString değerini kendi veritabanınıza göre ayarlamalısınız.
2. WebApi projesini başlatınız.



## API Kullanımı

#### Ürün Ekleme

```http
  GET /api/Product/CreateOrEdit
```

Örnek Data:
```
> {
      "productCode": "HALI-001",
      "productGroups": "ev-dekorasyon,halilarda-kampanya",
      "brand": "MERİNOS",
      "productName": "Merinos 001 Halı",
      "categoryId": 1,
      "categoryName": "ev-dekorasyon",
      "price": 100,
      "quatity": 1,
    },
```

#### Kampanya Ekleme

```http
  GET /api/Campaign/CreateOrEdit
```

Örnek Data:
```
> {
    "campaignLevel": 3,
    "campaignName": "250TL-Uzerine-Ev-Dekorasyon-Kategorisinde-25TL-Indirim",
    "discountPrice": 25,
    "minPrice": 250,
    "beginDate": "2022-10-26",
    "endDate": "2022-10-28",
    "isActive": true,
    "quantityPerBasket": 1,
    "campaignLevelName": "Ev-Dekorasyon",
  }
```
"campaignLevel" alanı kampanyanın seviyesini belirtmektedir. Örneğin "Kategori" seviyesinde bir kampanya hazırlanıyorsa bu değerein "3" olması gerekmetedir.
"campaignLevelName" alanı ise hangi kampanya seviyesinde hangi değer üzerinden hesaplama yapılacağını belirtir. Örneğin Kategori (Level 3) seviyesinde bir kampanya atıyorsak hangi kategoride indirim uygulanacağı ("ev-dekorasyon) burada verilir.

 Enum yapısı aşağıdaki gibidir.
```
CampaignLevel
    {
       Product = 1,
       Brand = 2,
       Category = 3,
       ProductGroup = 4,
       All = 5,
    }
```
#### Sepete Ürün Ekleme 

```http
  GET /api/Basket/CreateOrEdit
```

Örnek Data:
```
> {
        "productCode": "SHP-001",
        "orderCode": "ORD-001",
  }
```
Burada "orderCode" alanı sipariş numarasını temsil etmektedir. Aynı sepette olması gereken ürünlerin aynı "orderCode" ile eklenmesi gerekmektedir.

#### Kampanya Hesaplama

```http
  GET /api/Basket/GetByOrderCode
```

Örnek Data:
```
> {
      "productCode": "HALI-001",
      "productGroups": "ev-dekorasyon,halilarda-kampanya",
      "brand": "MERİNOS",
      "productName": "Merinos 001 Halı",
      "categoryId": 1,
      "categoryName": "ev-dekorasyon",
      "price": 100,
      "quatity": 1,
    },
```
Sipariş numarası (orderCode) verilerek ilgili sepetteki ürünlerin ve kampanyaların eşleşmesini ve hesaplamasını yapar.
Toplam indirimli fiyat response data içerisindeki "TotalDiscountedPrice" alanıdır.


#### Kampanya Passive Yapma

```http
  GET /api/Campaign/SetPassive
```

Örnek Data:
```
> {
      "campaignId" = 1
  }
```

