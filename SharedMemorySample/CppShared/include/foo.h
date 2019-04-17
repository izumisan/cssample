#ifndef  FOO_H

constexpr int FooNameSize = 8;
constexpr int FooArraySize = 8;

struct Foo
{
    int count;
    double value;
    bool lucky;
    char name[FooNameSize];
    int array[FooArraySize];
    bool exitFlag;
};

/*
Fooデータ構造(64byte)

  |0 1 2 3 4 5 6 7|
--+-+-+-+-+-+-+-+-+
0 |count  |* * * *|
1 |value          |
2 |?|name         |
3 | |* * *|array  |
4 |               |
5 |               |
6 |               |
7 |       |?|* * *|

- 64bitOSだと、8byte単位で配置される
- boolは1byte
*/

#endif // FOO_H
