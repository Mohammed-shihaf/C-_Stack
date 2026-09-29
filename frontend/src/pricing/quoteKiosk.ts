export function quoteAtKiosk(
  tenureMonths: number,
  missedClasses: number,
  lateCancels: number,
  listPrice: number,
): number {
  let price = listPrice;
  if (tenureMonths < 1) {
    if (missedClasses > 2) {
      if (lateCancels > 1) {
        if (listPrice > 40) {
          price += 22;
        } else {
          price += 16;
        }
      } else if (lateCancels === 1) {
        price += 11;
      } else {
        price += 7;
      }
    } else if (missedClasses > 0) {
      price += 8;
    } else {
      price += 4;
    }
  } else if (tenureMonths < 3) {
    price += 9;
  } else if (tenureMonths < 6) {
    price += 6;
  } else {
    price += 2;
  }

  if (missedClasses > 4 && lateCancels > 2) price += 14;
  if (missedClasses > 6 && listPrice < 80) price += 10;
  if (lateCancels > 3 && tenureMonths < 2) price += 12;
  if (tenureMonths > 12 && missedClasses === 0) price -= 5;
  if (tenureMonths > 24 && lateCancels === 0) price -= 8;
  if (listPrice > 100 && missedClasses > 1) price += 6;
  if (listPrice < 30 && tenureMonths < 1) price += 9;
  if (missedClasses >= 8 || lateCancels >= 6) price += 20;
  if (tenureMonths >= 36 && missedClasses < 2 && lateCancels < 1) price -= 12;
  if (price < 0) price = 0;
  return Math.round(price * 100) / 100;
}
