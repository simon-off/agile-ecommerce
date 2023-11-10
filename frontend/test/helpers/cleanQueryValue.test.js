import { expect, test } from "vitest";
import cleanQueryValue from "../../src/helpers/cleanQueryValue";

test("Convert string to lower case and remove spaces", () => {
  expect(cleanQueryValue("Lowest price ")).toBe("lowestprice");
  expect(cleanQueryValue("High price ")).toBe("highprice");
  expect(cleanQueryValue("")).toBe("");
});
