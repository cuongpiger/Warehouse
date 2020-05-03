import sys

class MyCircle:
    def __init__(self, radius):
        self.radius = radius

    def calcPerimeter(self):
        return 2*self.radius*3.14

    def calcArea(self):
        return 3.14*self.radius**2

    def __str__(self):
        return 'Area {0} - Perimeter {1}'.format(self.calcArea(), self.calcPerimeter())

class MyRect:
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def calcPerimeter(self):
        return 2*(self.height + self.width)

    def calcArea(self):
        return self.height*self.width

    def __str__(self):
        return 'Area {0} - Perimeter {1}'.format(self.calcArea(), self.calcPerimeter())

opt = sys.argv[1]

if opt == 'circle':
    r = float(input('Enter radius: '))
    
    cir = MyCircle(r)
    print(cir)
elif opt == 'rect':
    w = float(input('Enter width: '))
    h = float(input('Enter height: '))

    rec = MyRect(w, h)
    print(rec)
else:
    print('Good bye!')
