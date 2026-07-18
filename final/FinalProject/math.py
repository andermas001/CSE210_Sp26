# help preform simple calculations for the program

staminaPct = .00 * 100
accuracy = 0.95

if staminaPct < 0.25:
    accuracy -= (0.8 - (staminaPct * 3))

print (accuracy)

# 
# {HitChance} = 0.002 times ({Stamina}-25)+0.85)

# ({HitChance} = -0.00008 times ({Stamina}^{2})+0.012  {Stamina}+0.60)


accuracy = -0.00008 * (staminaPct**2) + 0.012 * staminaPct + .6
print (accuracy)