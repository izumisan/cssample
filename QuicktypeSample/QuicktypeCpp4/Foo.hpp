//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     Foo.hpp data = nlohmann::json::parse(jsonString);

#pragma once

#include <nlohmann/json.hpp>
#include "helper.hpp"

#include "FooValue.hpp"

namespace quicktype {
    using nlohmann::json;

    class Foo {
        public:
        Foo() = default;
        virtual ~Foo() = default;

        private:
        std::string name;
        FooValue foo_value;

        public:
        const std::string & get_name() const { return name; }
        std::string & get_mutable_name() { return name; }
        void set_name(const std::string & value) { this->name = value; }

        const FooValue & get_foo_value() const { return foo_value; }
        FooValue & get_mutable_foo_value() { return foo_value; }
        void set_foo_value(const FooValue & value) { this->foo_value = value; }
    };
}
