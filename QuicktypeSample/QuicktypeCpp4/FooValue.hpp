//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     FooValue.hpp data = nlohmann::json::parse(jsonString);

#pragma once

#include <nlohmann/json.hpp>
#include "helper.hpp"

namespace quicktype {
    using nlohmann::json;

    class FooValue {
        public:
        FooValue() = default;
        virtual ~FooValue() = default;

        private:
        std::string value1;
        std::string value2;

        public:
        const std::string & get_value1() const { return value1; }
        std::string & get_mutable_value1() { return value1; }
        void set_value1(const std::string & value) { this->value1 = value; }

        const std::string & get_value2() const { return value2; }
        std::string & get_mutable_value2() { return value2; }
        void set_value2(const std::string & value) { this->value2 = value; }
    };
}
