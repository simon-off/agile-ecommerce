export function convertToSlug(input: string) {
  return input.toLowerCase().split(" ").join("-");
}
