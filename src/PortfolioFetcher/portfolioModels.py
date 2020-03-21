
class Asset:
   def __init__(self, name, units, unitPrice, valueSEK):
     self.name = name
     self.units = units
     self.unitPrice = unitPrice
     self.valueSEK = valueSEK


class Input:

    def __init__(self, ssn, accountNbr):
      self.ssn = ssn
      self.accountNbr = accountNbr