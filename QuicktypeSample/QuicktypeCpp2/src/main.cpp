#include <iostream>
#include "welcome.h"

void deserializeCheck();
void serializeCheck();

int main()
{
    deserializeCheck();

    serializeCheck();

    return 0;
}

/*!
  @brief  デシリアライズ動作チェック
*/
void deserializeCheck()
{
    std::cout << "-----" << __func__ << std::endl;

    auto&& samplejson = R"({
    "greeting": "Welcome to quicktype!",
    "instructions": [
      "Type or paste JSON here",
      "Or choose a sample above",
      "quicktype will generate code in your",
      "chosen language to parse the sample data"
    ]
})"_json;

    auto&& welcome = quicktype::Welcome();
    nlohmann::from_json( samplejson, welcome );

    std::cout << welcome.get_greeting() << std::endl;
    for ( auto&& element : welcome.get_instructions() )
    {
        std::cout << element << std::endl;
    }
}

/*!
  @brief  シリアライズ動作チェック
*/
void serializeCheck()
{
    std::cout << "-----" << __func__ << std::endl;

    auto&& welcome = quicktype::Welcome();
    welcome.set_greeting( "foo" );
    welcome.set_instructions( { "item 0", "item 1", "item 2" } );

    auto&& json = nlohmann::json();
    nlohmann::to_json( json, welcome );

    auto&& str = json.dump();

    std::cout << str << std::endl;
}
