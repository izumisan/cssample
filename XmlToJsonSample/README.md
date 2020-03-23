# README

Json.NETでXMLドキュメントをJsonドキュメントに変換するサンプル

# XML -> JSON

■ 変換前
```xml
<?xml version="1.0" encoding="utf-8"?>
<Usすると、
  <User id="001">
    <name>太郎</name>
    <age>30</age>
  </User>
  <User id="002">
    <name>次郎</name>
    <age>20</age>
  </User>
  <User id="003">
    <name>三郎</name>
    <age>10</age>
  </User>
</Users>
```

■ 変換後
```json
{
  "?xml": {
    "@version": "1.0",
    "@encoding": "utf-8"
  },
  "Users": {
    "User": [
      {
        "@id": "001",
        "name": "太郎",
        "age": "30"
      },
      {
        "@id": "002",
        "name": "次郎",
        "age": "20"
      },
      {
        "@id": "003",
        "name": "三郎",
        "age": "10"
      }
    ]
  }
}
```

# Tips

- `JsonConvert.SerializeXmlNode()` に `System.Xml.XmlDocument` オブジェクトを渡すと、xmlをjsonに変換できる
- `JsonConvert.SerializeXmlNode()` の第3引数に `true` を指定すると、jsonの最上位カッコ`{}`が省略できる
- XMLの属性はjsonでは`@`付きのkeyになる模様（一般的なルール？）
