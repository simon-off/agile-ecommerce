export default function getCookieByName(cookieName) {
  const decodedCookie = decodeURIComponent(document.cookie);
  const cookieArray = decodedCookie.split(";");

  for (let i = 0; i < cookieArray.length; i++) {
    const [key, value] = cookieArray[i].split("=");

    if (key.trim() == cookieName) {
      return value;
    }
  }

  return null;
}
