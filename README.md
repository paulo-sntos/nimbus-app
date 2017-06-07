# Nimbus

Previsão do tempo baseada em localização.

# Conceito

O Nimbus foi desenvolvido como forma de aprendizado da plataforma Xamarin.Forms, com o objetivo de conhecer de maneira rápida e breve as possibilidades de desenvolvimento utilizando código C# e XAML, ao longo da Maratona Xamarin Intermediária 2017.

# Desenvolvimento

A aplicação foi desenvolvida utilizando o plugin Xam.Plugin.Geolocator para obter a localização à partir do GPS do dispositivo, e realiza a busca por informações de clima na Weather API disponibilizada pela OpenWeatherMap.org. São enviados os dados de Latitude e Longitude para a Weather API e ela retorna os dados da previsão do tempo para a aplicação.
O Nimbus também conta com uma tela onde é realizada uma Autenticação via Facebook (Social Login) e as informações básicas recuperadas via Social Login são exibidas em outra tela da aplicação, e conta também com o recebimento de notificações Push simples através de configuração conjunta via Azure e Firebase, onde as notificações são disparadas à partir do Notification Hub do Azure.

# Vídeo de apresentação
https://www.youtube.com/watch?v=9FUxumJ2gPg
