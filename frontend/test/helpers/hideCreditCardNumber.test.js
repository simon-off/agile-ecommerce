import { expect, test } from "vitest";
import hideCreditCardNumber from "../../src/helpers/hideCreditCardNumber";

test("Obfuscate credit card number with stars (*)", () => {
  expect(hideCreditCardNumber("1234 5678 9012 3456")).toBe("**** **** **** 3456");
  expect(hideCreditCardNumber("asdf ghjk")).toBe("**** ghjk");
  expect(hideCreditCardNumber("")).toBe("");
});
