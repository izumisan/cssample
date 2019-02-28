//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     Welcome data = nlohmann::json::parse(jsonString);

#pragma once

#include "json.hpp"

#include <optional>
#include <stdexcept>
#include <regex>

namespace quicktype {
    using nlohmann::json;

    inline json get_untyped(const json & j, const char * property) {
        if (j.find(property) != j.end()) {
            return j.at(property).get<json>();
        }
        return json();
    }

    inline json get_untyped(const json & j, std::string property) {
        return get_untyped(j, property.data());
    }

    class Welcome {
        public:
        Welcome() = default;
        virtual ~Welcome() = default;

        private:
        std::string greeting;
        std::vector<std::string> instructions;

        public:
        const std::string & get_greeting() const { return greeting; }
        std::string & get_mutable_greeting() { return greeting; }
        void set_greeting(const std::string & value) { this->greeting = value; }

        const std::vector<std::string> & get_instructions() const { return instructions; }
        std::vector<std::string> & get_mutable_instructions() { return instructions; }
        void set_instructions(const std::vector<std::string> & value) { this->instructions = value; }
    };
}

namespace nlohmann {
    void from_json(const json & j, quicktype::Welcome & x);
    void to_json(json & j, const quicktype::Welcome & x);

    inline void from_json(const json & j, quicktype::Welcome& x) {
        x.set_greeting(j.at("greeting").get<std::string>());
        x.set_instructions(j.at("instructions").get<std::vector<std::string>>());
    }

    inline void to_json(json & j, const quicktype::Welcome & x) {
        j = json::object();
        j["greeting"] = x.get_greeting();
        j["instructions"] = x.get_instructions();
    }
}
