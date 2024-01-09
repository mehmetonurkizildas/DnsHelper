# DnsHelper

Bu proje .Net Core 8 ile yazılmıştır. <br>
Projenin amacı girilen domaine göre A,Mx ve Ns kayıtlarını dönen bir Web API. <br>
Projede AspNetCoreRateLimit uygulanmıştır. (Her bir IP için 1 saniye içinde en fazla 5 istek yapabilir.) <br> 
Projede HttpLoggingMiddleware eklenmiştir. Her request NLog conf. bağlı olarak günlük olarak klasörlerde saklanmaktadır. <br>

