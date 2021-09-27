# Price Conversion API

Convert a value from a source currency to a target currency.

```
/api/priceconversion?source={source_currency}&target={target_currency}&price={price}
```

e.g.

```
/api/priceconversion?source=GBR&target=EUR&price=1.00
```


## Changes to consider
 - Would be good to add intergation tests on the api
 - Could maybe provice better feedback if the api is down
 - Could improve the validation of the currency codes to check its ISO and give feedback
 - Add the base address as an environment variable
