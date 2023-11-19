export function convertToSlug(input: string) {
  return input.toLowerCase().split(" ").join("-");
}

export function convertToQueryParam(input: string) {
  return input.toLowerCase().replace(/\s/g, "");
}
