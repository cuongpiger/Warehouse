class Electricity:
    def __init__(self, kwh):
        self.kwh = kwh
        self.cost = self()
    
    def __call__(self):
        kwh = self.kwh
        cost = 0

        if kwh > 400:
            cost += (kwh - 400) * 2.927
            kwh = 400
        
        if kwh > 300:
            cost += (kwh - 300) * 2.834
            kwh = 300

        if kwh > 200:
            cost += (kwh - 200) * 2.536
            kwh = 200

        if kwh > 100:
            cost += (kwh - 100) * 2.014
            kwh = 100
        
        if kwh > 50:
            cost += (kwh - 50) * 1.734
            kwh = 50

        if kwh > 0:
            cost += kwh * 1.678
            kwh = 0

        cost += cost * 0.1
        
        return cost

    def __str__(self):
        return 'Kwh: {0} - Cost: {1}'.format(self.kwh, self.cost*1000)

kwh = float(input('Enter Kwh: '))
ele = Electricity(kwh)
print(ele)