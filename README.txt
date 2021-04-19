# DesafioXamarinCEP
 
- Foram realizadas as seguintes tarefas: 
1 - Consulta e gravação do CEP e endereço;
2 - Exibição da lista de endereços cadastrados e seus detalhes;
3 - Exibição do mapa, com base nos registros salvos; 

- As bibliotecas utilizadas para o banco local e o mapa foram:
1 - Banco Local: Realm;
2 - Mapa: Xamarin.Forms.Maps, que no caso do android utiliza o Google maps;  
 

Obs: O aplicativo foi desenvolvido na plataforma Android, pois não possuo dispositivo IOS;
- No Android manifest é necessário adicionar uma chave do Google Maps, aonde tem a seguinte paramatero: "COLE SUA API KEY AQUI", na
tag: <meta-data android:name="com.google.android.geo.API_KEY" android:value="COLE SUA API KEY AQUI"/>; 