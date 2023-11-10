export default function cleanQueryValue(value) {
  return value.replace(/\s/g, "").toLowerCase();
}
