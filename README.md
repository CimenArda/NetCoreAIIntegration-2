# 🚀 Basit Yapay Zeka Projeleri

Bu repo içerisinde yapay zekâ ile ilgili geliştirdiğim basit ve öğretici projeler yer almaktadır.  
Her proje, farklı bir kullanım senaryosunu göstermek ve öğrenme sürecimi desteklemek için hazırlanmıştır.  

---

## 📌 Deepgram Speech-to-Text

### Açıklama  
Deepgram API kullanarak bir ses dosyasını metne çevirir. Kullanıcıdan verilen MP3 dosyasını alır, HTTP isteğiyle Deepgram’ın nova-2-general modeline gönderir ve dönen JSON’dan transcript bilgisini çıkarır. Çalıştırıldığında, ses dosyasının yazıya dönüştürülmüş hali ekranda görüntülenir.

### Görsel  
<img width="865" height="244" alt="Resim1" src="https://github.com/user-attachments/assets/44da077b-898f-4738-bc1c-d14827cdc68f" />


---

## 📌 Hugging Face Sentiment Analysis

### Açıklama  
Bu uygulama, kullanıcının girdiği bir yorumu Hugging Face’in sentiment analysis modeline göndererek duygu durumunu analiz eder. Program, Hugging Face API’sine HTTP isteği atar, dönen JSON sonucundan en yüksek güven skoruna sahip etiketi seçer ve bu etiketi Positive, Neutral veya Negative olarak kullanıcıya gösterir. Son olarak, tahminin güven oranını yüzde formatında ekrana yazdırır.

### Görsel  
<img width="945" height="258" alt="image" src="https://github.com/user-attachments/assets/fcb31dd2-408d-4f72-a164-9ebb98d148b0" />

---

## 📌 Hugging Face Text Summarization

### Açıklama  
Bu uygulama, kullanıcının girdiği uzun bir metni Hugging Face’in facebook/bart-large-cnn özetleme modeline göndererek daha kısa ve anlaşılır bir özet oluşturur. Program, önce kullanıcıdan metin alır ve boş olup olmadığını kontrol eder. Ardından bu metni JSON formatına çevirip Hugging Face API’sine bir HTTP POST isteği ile gönderir. API’den dönen sonuç JSON olarak alınır ve içinden "summary_text" alanı ayrıştırılır. Son olarak elde edilen özet, konsolda kullanıcıya gösterilir. Böylece uzun metinler otomatik olarak daha kısa, okunabilir paragraflara indirgenmiş olur.

### Görsel  
<img width="945" height="224" alt="image" src="https://github.com/user-attachments/assets/c7282ff4-f76a-4234-893e-48a1aea767f0" />

---

## 📌 Hugging Face Named Entity Recognition (NER)

### Açıklama  
Hugging Face’in bert-base-NER modelini kullanarak kullanıcıdan alınan bir metin üzerinde adlandırılmış varlık tanıma (NER) işlemi yapıyor. Konsola girilen yazıyı Hugging Face API’sine gönderiyor ve dönen JSON sonucundan kişi, kurum, yer gibi varlıkları ayıklıyor. Çıktıları daha okunabilir kılmak için “Score | Entity | Word” başlıkları altında tablo formatında listeliyor. Böylece kullanıcı, metindeki hangi kelimenin hangi kategoriye ait olduğunu ve modelin güven yüzdesini net bir şekilde görebiliyor. Bu küçük uygulama, haber takibi, belge analizi veya chatbot geliştirme gibi birçok senaryoda temel bir NER altyapısı olarak kullanılabilir.

### Görsel  
<img width="970" height="103" alt="image" src="https://github.com/user-attachments/assets/1664d784-cfd8-4a67-8b3a-c73d824dfa2d" />

---

## 📌 Hugging Face Question Answering

### Açıklama  
Bu uygulama, Hugging Face üzerindeki RoBERTa-base-squad2 modelini kullanarak soru-cevap yapar.  
Kullanıcı bir soru ve buna ait bağlam metnini girer, uygulama API üzerinden modeli çalıştırır.  
Model hem cevabı hem de bir güven puanı (confidence score) döndürür.  
Eğer güven puanı yüksekse (%50’nin üzerinde) cevap güvenilir kabul edilip gösterilir.  
Aksi halde uygulama kullanıcıya modelin cevabından emin olmadığını bildirir.

### Görsel  
<img width="1072" height="192" alt="image" src="https://github.com/user-attachments/assets/6a12e9e7-bc36-4877-82bf-c8c5c348a7ae" />

---

## 📌 Hugging Face Toxic Comment Classification

### Açıklama  
Bu uygulama, kullanıcıdan alınan bir yorumu Hugging Face Toxic-BERT modeline göndererek içerik analizi yapar.  
Model, yorumun toksik, hakaret, tehdit, müstehcen veya nefret içerikli olup olmadığını değerlendirir.  
Her bir kategori için yüzdelik skor hesaplanır ve kullanıcıya anlaşılır şekilde sunulur.  
Böylece girilen yorumların zararlı içerik barındırıp barındırmadığı kolayca tespit edilir.  
Uygulama, moderasyon veya içerik filtreleme sistemleri için temel bir örnek niteliğindedir.

### Görsel  
<img width="945" height="173" alt="image" src="https://github.com/user-attachments/assets/4707dc36-25f1-477d-b8c9-84740fdad6e0" />

---

## 📌 Claude Chatbot (Anthropic API)

### Açıklama  
Bu proje, Anthropic’in Claude modelini kullanarak çalışan bir konsol tabanlı sohbet uygulamasıdır. Kullanıcı, konsola yazdığı mesajı API aracılığıyla Claude’a gönderir ve anında akıllı yanıt alır. Uygulama, JSON formatında veri gönderip alarak modern API iletişimi mantığını gösterir. Asenkron yapı sayesinde cevap beklenirken uygulama donmadan çalışmaya devam eder.

### Görsel  
<img width="1010" height="441" alt="image" src="https://github.com/user-attachments/assets/00869904-46f2-41ac-a502-1ba7b8131dbc" />

---

## 📌 PDF to Summary with Claude

### Açıklama  
Bir PDF dosyasının tüm sayfalarından metni çıkarıp tek bir metin halinde birleştirir. Ardından bu metni, Anthropic Claude modeline “Türkçe analiz ve özet” isteği olarak gönderir. Uygulama, modern REST ilkeleriyle JSON tabanlı bir istek/yanıt akışı kullanır ve hata durumlarında ayrıntılı geri bildirim verir. Parametreler (model, max_tokens, temperature) sayesinde çıktı uzunluğu ve yaratıcılık seviyesi kontrol edilir. Sonuçta, PDF içeriğini hızla özetleyen pratik ve tekrar kullanılabilir bir metin-analiz hattı elde edilir.

### Görsel  
<img width="945" height="363" alt="image" src="https://github.com/user-attachments/assets/b8807b47-0df8-437c-898b-882651bd88ef" />

---

## 📌 Claude Text Generation

### Açıklama  
Anthropic Claude API’sini kullanarak otomatik metin üretimi yapan bir C# konsol programıdır. Kullanıcıdan alınan prompt doğrultusunda profesyonel bir iş başvuru e-postası gibi içerikler üretir. HTTP isteği aracılığıyla modele bağlanır, parametreler (model, max_tokens, temperature vb.) belirlenir. API’den dönen JSON yanıtı deserialize edilerek ekrana yazdırılır. Başarılı veya hatalı durumlarda kullanıcıya uygun geri bildirim verir.

### Görsel  
<img width="823" height="361" alt="image" src="https://github.com/user-attachments/assets/44d90710-184c-4468-a2cd-a2a8da1e3bb7" />

---

## 📌 Replicate AI Image Generation

### Açıklama  
Bu uygulama, Replicate API üzerinden yapay zeka ile görsel üretimi gerçekleştirmek için geliştirilmiştir. Kullanıcıdan alınan metin tabanlı prompt, bir modele gönderilir ve modelden üretilen görsellerin bilgilerini içeren JSON yanıtı alınır. Kullanıcı yalnızca istediği sahneyi veya nesneyi yazdığı prompt ile tanımlar. Sonuç olarak bu yapı, metin girdilerini görsele dönüştüren, AI tabanlı yaratıcı içerikler üretmek için kullanılabilen bir temel araç sunar.

### Görsel  
<img width="945" height="174" alt="image" src="https://github.com/user-attachments/assets/20517679-075f-4498-9ca4-ced53e76ccef" />
<img width="945" height="934" alt="image" src="https://github.com/user-attachments/assets/27d8d432-387d-43c6-b589-397b95b49516" />

---

## 📌 Azure Text-to-Speech

### Açıklama  
Bu uygulama, Microsoft Azure Cognitive Services altyapısını kullanarak yazıları sese dönüştüren programdır. Kullanıcıdan alınan veya kod içerisine eklenen Türkçe metinler, Azure’un Text-to-Speech (TTS) servisine gönderilir ve seçilen ses karakteriyle doğal bir şekilde okunarak WAV formatında ses dosyası olarak kaydedilir. Program, önce Azure’dan geçici bir erişim token’ı alır, ardından SSML formatında oluşturulan metni TTS servisine iletir. Başarılı dönüşlerde ses verisi output2.wav dosyasına yazılır, hatalı durumlarda ise ayrıntılı hata mesajları konsolda gösterilir. 

### Görsel  
<img width="945" height="578" alt="image" src="https://github.com/user-attachments/assets/a399cdff-c9ee-4b13-8b97-2ecaf0defde9" />

---

## 📌 Azure Computer Vision

### Açıklama  
Uygulama, verilen görseli byte formatında API’ye göndererek resim hakkında açıklamalar (caption) ve güven skorları elde ediyor. Sonuçlar JSON formatında parse edilip okunabilir şekilde konsola yazdırılıyor. Başarılı senaryolarda resmin içeriğine dair açıklamalar listelenirken, başarısız senaryolarda hata kodu ve detay mesajı ekrana yansıtılıyor.

### Görsel  
<img width="945" height="149" alt="image" src="https://github.com/user-attachments/assets/a3871453-fbfd-49c8-b151-cb55cc289aac" />

<img width="945" height="532" alt="image" src="https://github.com/user-attachments/assets/802ff775-8d44-46e0-9e9a-f50ff7711def" />

---

## 📌 Google Gemini Q&A

### Açıklama  
Bu uygulama, Google Gemini API’sine bağlanarak kullanıcıdan alınan metin tabanlı sorulara yapay zekâ ile yanıt üretiyor. Konsol üzerinden yazılan girdiler JSON formatında API’ye gönderiliyor ve alınan cevaplar işlenerek ekranda gösteriliyor. Kod, hata yönetimi için try-catch bloğu kullanarak JSON parse sırasında oluşabilecek sorunları yakalıyor.

### Görsel  

<img width="1043" height="422" alt="image" src="https://github.com/user-attachments/assets/a7bf217b-3a33-4dd4-bf2a-8d4f07cbf07e" />

---

## 📌 Google Gemini Role-based AI

### Açıklama  
Bu uygulama, Google Gemini API’sini kullanarak kullanıcıya rol bazlı yapay zekâ deneyimi sunuyor. Konsol ekranında kullanıcıya dört farklı rol seçeneği (Matematik Öğretmeni, Psikolog, Senior Yazılım Geliştirici, Finansal Yatırım Uzmanı) sunuluyor ve seçim yapıldıktan sonra model bu role uygun şekilde cevap üretiyor. Kullanıcının girdiği soru veya problem, seçilen rolün bağlamıyla birleştirilerek yapay zekâya gönderiliyor. API’den dönen JSON yanıtı ayrıştırılarak sadece modelin verdiği metin cevabı ekrana yansıtılıyor. Böylece, aynı yapay zekâ modeli farklı rollere bürünerek çok yönlü danışmanlık sağlayabiliyor. Uygulama hem öğrenme, hem rehberlik, hem de profesyonel destek amaçlı senaryolarda pratik bir örnek sunuyor.

### Görsel  

<img width="945" height="353" alt="image" src="https://github.com/user-attachments/assets/ebc06856-c958-4597-bf53-451eba400942" />

---

## 📌 Google Gemini Content Planner

### Açıklama  
Bu uygulama, kullanıcıdan alınan bir fikri adım adım sorularla şekillendirip en sonunda içerik planına dönüştürmek üzere tasarlanmıştır. Program, Google Gemini API’si üzerinden çalışan bir “yapay zekâ içerik planlayıcısı” rolü üstlenir. Kullanıcı ilk fikrini girdikten sonra, uygulama beş tur boyunca ona yönlendirici sorular sorar ve yanıtlarını dikkate alarak fikri derinleştirir. Her yanıt, prompt’a eklenerek yapay zekânın bağlamı sürekli güncel tutulur. Bu süreç tamamlandığında, elde edilen bilgiler ışığında Türkçe bir içerik planı oluşturulur. Böylece kullanıcı hem fikir geliştirme sürecinde yönlendirilmiş olur hem de sonunda somut bir plan çıktısı elde eder.

### Görsel  

<img width="945" height="312" alt="image" src="https://github.com/user-attachments/assets/694f51e6-19c2-4f09-bff0-d3b7979c0b3b" />

<img width="945" height="414" alt="image" src="https://github.com/user-attachments/assets/9e4bfb29-321c-4b73-bc3d-a3d4b85954a8" />

---

## 📌 OpenAI Code Assistant

### Açıklama  
Kullanıcıların yazdığı C# kodunu OpenAI API’sine göndererek üç farklı işlem gerçekleştirmesini sağlar: kod açıklaması üretme, refactoring yapma veya test case oluşturma. Konsol üzerinden seçim yapılır ve kullanıcı kodunu yazıp "END" ile tamamlar. Uygulama, seçilen işleme göre kodu OpenAI’ye gönderir ve modelden gelen yanıtı ekrana yansıtır. Böylece kullanıcılar yazdıkları kodun daha anlaşılır hale gelmesini, yeniden düzenlenmesini veya otomatik test senaryolarının üretilmesini sağlayabilir. Basit menü yapısı ve OpenAI entegrasyonu sayesinde pratik bir kod editörü deneyimi sunar.

### Görsel  

<img width="945" height="378" alt="image" src="https://github.com/user-attachments/assets/587708a3-0c57-406f-901f-a421b1ea7d9b" />

---

## 📌 Stability AI Image Generation

### Açıklama  
Bu uygulama, kullanıcıdan alınan bir prompt’u Stability AI Stable Diffusion XL API’sine göndererek görsel üretir. API’den dönen base64 formatındaki görsel verisi çözülerek PNG dosyasına dönüştürülür ve bilgisayara kaydedilir. Uygulama, görsel boyutları, adım sayısı ve cfg_scale gibi parametrelerle özelleştirilebilir.

### Görsel  

<img width="945" height="397" alt="image" src="https://github.com/user-attachments/assets/b59c91cb-8ba8-482d-bf0d-0e9a40220d31" />

---

## 📌 Replicate AI Video Generation

### Açıklama  
Bu uygulama, kullanıcıdan bir metin tabanlı prompt alarak Replicate API’si üzerinden yapay zekâ destekli video üretimi gerçekleştirir. Kullanıcı tarafından girilen prompt, seçili model sürümüne (version) parametrelerle birlikte JSON formatında gönderilir. Sunucu, video üretimini başlattıktan sonra uygulama belirli aralıklarla işlem durumunu kontrol eder. İşlem tamamlandığında, üretilen videonun URL’si elde edilir. Uygulama bu URL üzerinden videoyu indirir ve eşsiz bir dosya adıyla bilgisayara kaydeder. Daha sonra videoyu sistemin varsayılan oynatıcısında otomatik olarak açar. Böylece kullanıcı kolay ve hızlı bir şekilde kendi metinlerinden kısa videolar oluşturabilir.

### Görsel  

<img width="945" height="366" alt="image" src="https://github.com/user-attachments/assets/cdf6f3e5-8a5f-4a7e-b506-8b7dd17b4236" />

---

## 📌 Voice-based Chatbot

### Açıklama  
Bu uygulama, kullanıcı ile sesli etkileşim kurabilen bir chatbot mantığı üzerine geliştirilmiştir. Kullanıcı, enter tuşuna bastığında mikrofon kaydı başlar ve konuşma ses dosyası olarak kaydedilir. Kaydedilen ses dosyası OpenAI Whisper API’si kullanılarak metne dönüştürülür. Elde edilen metin, ChatGPT API’sine gönderilerek doğal dil işleme yoluyla uygun bir yanıt alınır. Alınan yanıt hem konsolda yazı olarak görüntülenir hem de sistemin konuşma sentezleyicisi tarafından sesli şekilde geri okunur. Bu sayede uygulama, tam bir sesli asistan deneyimi sunmaktadır. Uygulama, NAudio kütüphanesi ile ses kaydı, Whisper ile sesin metne çevrilmesi ve GPT ile yanıt üretimi gibi modern yapay zeka teknolojilerini bir araya getirmektedir.

### Görsel  

<img width="945" height="324" alt="image" src="https://github.com/user-attachments/assets/ead3e988-771b-44ce-81c9-bea49011b3a8" />
