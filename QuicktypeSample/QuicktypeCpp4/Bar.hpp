//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     Bar.hpp data = nlohmann::json::parse(jsonString);

#pragma once

#include <nlohmann/json.hpp>
#include "helper.hpp"

namespace quicktype {
    using nlohmann::json;

    class Bar {
        public:
        Bar() = default;
        virtual ~Bar() = default;

        private:
        std::string name;
        int64_t value;

        public:
        const std::string & get_name() const { return name; }
        std::string & get_mutable_name() { return name; }
        void set_name(const std::string & value) { this->name = value; }

        const int64_t & get_value() const { return value; }
        int64_t & get_mutable_value() { return value; }
        void set_value(const int64_t & value) { this->value = value; }
    };
}
