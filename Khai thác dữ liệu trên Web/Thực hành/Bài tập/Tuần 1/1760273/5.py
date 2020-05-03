class Prime:
    def __init__(self, n):
        self.n = n
        self.primes = self.sieveOfEratosthenes()

    def sieveOfEratosthenes(self):
        mark = [True]*(self.n + 1)
        primes = []
        mark[0] = mark[1] = False

        for i in range(2, int(self.n**0.5) + 1):
            if mark[i] == True:
                for j in range(i*i, self.n + 1, i):
                    mark[j] = False

        for i in range(2, self.n + 1):
            if mark[i] == True:
                primes.append(i)

        return primes

    def __str__(self):
        res = '';
        
        if self.primes[-1] == self.n:
            res += '{0} is a prime number\n'.format(self.n)
            res += 'The prime numbers are less than {0} is: '.format(self.n)
            res += ', '.join(map(str, self.primes[:-1]))
        else:
            res += '{0} is not a prime number\n'.format(self.n)
            res += 'The prime numbers are less than {0} is: '.format(self.n)
            res += ', '.join(map(str, self.primes))

        return res

n = int(input('Enter n: '))
prm = Prime(n)
print(prm)