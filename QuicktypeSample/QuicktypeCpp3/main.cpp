#include <iostream>
#include "foo.h"

int main()
{
    auto&& json = R"({
    "name": "foo",
    "ivalue": 1,
    "dvalue": 3.14,
    "success": true,
    "key": { "value": 7 },
    "key2": { "value": 77 }
})"_json;

    auto&& foo = quicktype::Foo();
    nlohmann::from_json( json, foo );

    std::cout << foo.get_name() << std::endl;

    return 0;
}
