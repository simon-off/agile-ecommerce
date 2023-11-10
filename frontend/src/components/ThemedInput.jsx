import { useState } from "react";

export default function ThemedInput({
  children,
  className = "",
  label,
  regex,
  error = "Invalid input",
  ...inputAttributes
}) {
  const [isValid, setIsValid] = useState(true);

  const inputHandler = (e) => {
    if (!regex) {
      return;
    }
    const re = new RegExp(regex);
    setIsValid(re.test(e.target.value));
  };

  return (
    <label className={`themed-input ${className}`}>
      <span className="label">{label}</span>
      <div className="input-area">
        <input onInput={inputHandler} type="text" {...inputAttributes} />
        <span className="icon">{children}</span>
      </div>
      <span className="error">{!isValid && error}</span>
    </label>
  );
}
