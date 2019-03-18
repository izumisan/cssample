#include <iostream>
#include "Generators.hpp"
#include "Foo.hpp"
#include "Bar.hpp"

void serializeCheck();
void deserializeCheck();

int main()
{
    serializeCheck();

    deserializeCheck();

    return 0;
}

void serializeCheck()
{
    auto&& foojson = R"({
    "name": "foo",
    "fooValue": {
        "value1": "foo value1",
        "value2": "foo value2"
    }
})"_json;

    auto&& foo = quicktype::Foo();
    nlohmann::from_json( foojson, foo );

    auto&& barjson = R"({
    "name": "bar",
    "value": 777
})"_json;

    auto&& bar = quicktype::Bar();
    nlohmann::from_json( barjson, bar );

    std::cout << foo.get_name() << std::endl;
    std::cout << bar.get_name() << "," << bar.get_value() << std::endl;
}

void deserializeCheck()
{
    auto&& foo = quicktype::Foo();
    foo.set_name( "foo-foo" );

    auto&& bar = quicktype::Bar();
    bar.set_name( "bar-bar" );
    bar.set_value( 123 );

    auto&& foojson = nlohmann::json();
    nlohmann::to_json( foojson, foo );

    auto&& barjson = nlohmann::json();
    nlohmann::to_json( barjson, bar );

    std::cout << foojson.dump() << std::endl;
    std::cout << barjson.dump() << std::endl;
}
