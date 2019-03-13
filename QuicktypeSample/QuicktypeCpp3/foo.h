//  To parse this JSON data, first install
//
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     quicktype::Foo data = nlohmann::json::parse(jsonString);

#pragma once

#include <nlohmann/json.hpp>

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

    class Key {
        public:
        Key() = default;
        virtual ~Key() = default;

        private:
        int64_t value;

        public:
        const int64_t & get_value() const { return value; }
        int64_t & get_mutable_value() { return value; }
        void set_value(const int64_t & value) { this->value = value; }
    };

    class Foo {
        public:
        Foo() = default;
        virtual ~Foo() = default;

        private:
        std::string name;
        int64_t ivalue;
        double dvalue;
        bool success;
        quicktype::Key key;
        quicktype::Key key2;

        public:
        const std::string & get_name() const { return name; }
        std::string & get_mutable_name() { return name; }
        void set_name(const std::string & value) { this->name = value; }

        const int64_t & get_ivalue() const { return ivalue; }
        int64_t & get_mutable_ivalue() { return ivalue; }
        void set_ivalue(const int64_t & value) { this->ivalue = value; }

        const double & get_dvalue() const { return dvalue; }
        double & get_mutable_dvalue() { return dvalue; }
        void set_dvalue(const double & value) { this->dvalue = value; }

        const bool & get_success() const { return success; }
        bool & get_mutable_success() { return success; }
        void set_success(const bool & value) { this->success = value; }

        const quicktype::Key & get_key() const { return key; }
        quicktype::Key & get_mutable_key() { return key; }
        void set_key(const quicktype::Key & value) { this->key = value; }

        const quicktype::Key & get_key2() const { return key2; }
        quicktype::Key & get_mutable_key2() { return key2; }
        void set_key2(const quicktype::Key & value) { this->key2 = value; }
    };
}

namespace nlohmann {
namespace detail {
    void from_json(const json & j, quicktype::Key & x);
    void to_json(json & j, const quicktype::Key & x);

    void from_json(const json & j, quicktype::Foo & x);
    void to_json(json & j, const quicktype::Foo & x);

    inline void from_json(const json & j, quicktype::Key& x) {
        x.set_value(j.at("value").get<int64_t>());
    }

    inline void to_json(json & j, const quicktype::Key & x) {
        j = json::object();
        j["value"] = x.get_value();
    }

    inline void from_json(const json & j, quicktype::Foo& x) {
        x.set_name(j.at("name").get<std::string>());
        x.set_ivalue(j.at("ivalue").get<int64_t>());
        x.set_dvalue(j.at("dvalue").get<double>());
        x.set_success(j.at("success").get<bool>());
        x.set_key(j.at("key").get<quicktype::Key>());
        x.set_key2(j.at("key2").get<quicktype::Key>());
    }

    inline void to_json(json & j, const quicktype::Foo & x) {
        j = json::object();
        j["name"] = x.get_name();
        j["ivalue"] = x.get_ivalue();
        j["dvalue"] = x.get_dvalue();
        j["success"] = x.get_success();
        j["key"] = x.get_key();
        j["key2"] = x.get_key2();
    }
}
}
