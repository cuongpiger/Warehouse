import math

class Triangle:
    def __init__(self, a, b, c):
        self.a = a
        self.b = b
        self.c = c

    def isTriangle(self):
        c = max([self.a, self.b, self.c])
        ab = (self.a + self.b + self.c) - c

        return ab > c

    def calcPerimeter(self):
        return self.a + self.b + self.c

    def calcArea(self):
        p = self.calcPerimeter()/2
        return math.sqrt(p*(p - self.a)*(p - self.b)*(p - self.c))

    def __str__(self):
        if self.isTriangle():
            return 'Area: {0} - Perimeter: {1}'.format(self.calcArea(), self.calcPerimeter())
        else:
            return 'Your data can not create a triangle!'

a = float(input('Enter edge a: '))
b = float(input('Enter edge b: '))
c = float(input('Enter edge c: '))

tri = Triangle(a, b, c)
print(tri)