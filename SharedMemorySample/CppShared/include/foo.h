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
Foo�f�[�^�\��(64byte)

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

- 64bitOS���ƁA8byte�P�ʂŔz�u�����
- bool��1byte
*/

#endif // FOO_H
