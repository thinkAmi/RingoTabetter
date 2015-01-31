RingoTabetter
=============

[りんごたべたーAPI](http://ringo-tabetter-api.herokuapp.com/) のAPIから返ってくるJSONを元に、Highchartsでグラフを表示します。

OWIN, SelfHost, SuperSimpleViewEngineを使ったNancyで動作しています。

APIのソースコードはこちらです。  
[thinkAmi/RingoTabetterApi · GitHub](https://github.com/thinkAmi/RingoTabetterApi)

また、Heroku上で稼働しているサイトはこちらです。  
[りんごたべたー - Heroku](http://ringo-tabetter-cs.herokuapp.com/)

　  
# 開発環境
- Windows7 x64
- .NET Framework 4.5
- PostgreSQL x64 9.3.5
- Ruby2.1.5 (RubyInstaller)

　  
# アプリで使っているもの
- Heroku buildpack
  - [friism/heroku-buildpack-mono](https://github.com/friism/heroku-buildpack-mono)
- NuGet
  - Nancy.Owin 0.23.2
  - Microsoft.Owin.Hosting 3.0.0
  - Microsoft.Owin.Host.HttpListener 3.0.0
- Highcharts 4.0.4
- jQuery 2.1.3

　  
# セットアップ
## ローカル
### 動作するポート
ポートは`8765`になります。

ポートを変更する場合は[Program.csのこのあたり](https://github.com/thinkAmi/RingoTabetter/blob/c11d0bfdb48b704a509878cbfbcae6ff6016967b/RingoTabetter/Program.cs#L18)を修正してください。

　  
### 名前空間予約の構成の追加
Self Hostingの場合、ローカルで実行するには名前空間予約の構成の追加が必要になります。  
[HTTP および HTTPS の構成 - MSDN](http://msdn.microsoft.com/ja-jp/library/ms733768.aspx)

そのため、PowerShellを管理者で起動し、まずは実行中のユーザーを確認します。

```
whoami
```

次に、そのユーザーに対して、パーミッションの追加を行います。<UserName>は、上記のwhoamiで取得したものをコピペすれば良いです。

```
netsh http add urlacl url=http://+:8765/ user=<UserName>
```

　  
## Heroku
### 手動で構築する場合
1. `git clone`
2. `heroku create <アプリ名>`
3. `heroku config:add BUILDPACK_URL=https://github.com/friism/heroku-buildpack-mono`
4. `git push heroku master`

　  
### Heroku buttonを使う場合
以下をクリックしてデプロイします。
<p><a href="https://heroku.com/deploy?template=https://github.com/thinkAmi/RingoTabetter"> <img alt="Deploy" src="https://www.herokucdn.com/deploy/button.png"></a></p>

　  
# ライセンス
MIT

　  
# ブログ記事
- [C# + Nancy (OWIN, SelfHost, SSVE) + Dapper + Heroku + Highchartsで食べたリンゴの割合をグラフ化してみた - メモ的な思考的な](http://thinkami.hatenablog.com/entry/2015/01/14/064115)
