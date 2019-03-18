//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     Generators.hpp data = nlohmann::json::parse(jsonString);

#pragma once

#include <nlohmann/json.hpp>
#include "helper.hpp"

#include "Foo.hpp"
#include "FooValue.hpp"
#include "Bar.hpp"

namespace nlohmann {
    void from_json(const json & j, quicktype::Bar & x);
    void to_json(json & j, const quicktype::Bar & x);

    void from_json(const json & j, quicktype::FooValue & x);
    void to_json(json & j, const quicktype::FooValue & x);

    void from_json(const json & j, quicktype::Foo & x);
    void to_json(json & j, const quicktype::Foo & x);

    inline void from_json(const json & j, quicktype::Bar& x) {
        x.set_name(j.at("name").get<std::string>());
        x.set_value(j.at("value").get<int64_t>());
    }

    inline void to_json(json & j, const quicktype::Bar & x) {
        j = json::object();
        j["name"] = x.get_name();
        j["value"] = x.get_value();
    }

    inline void from_json(const json & j, quicktype::FooValue& x) {
        x.set_value1(j.at("value1").get<std::string>());
        x.set_value2(j.at("value2").get<std::string>());
    }

    inline void to_json(json & j, const quicktype::FooValue & x) {
        j = json::object();
        j["value1"] = x.get_value1();
        j["value2"] = x.get_value2();
    }

    inline void from_json(const json & j, quicktype::Foo& x) {
        x.set_name(j.at("name").get<std::string>());
        x.set_foo_value(j.at("fooValue").get<quicktype::FooValue>());
    }

    inline void to_json(json & j, const quicktype::Foo & x) {
        j = json::object();
        j["name"] = x.get_name();
        j["fooValue"] = x.get_foo_value();
    }
}
