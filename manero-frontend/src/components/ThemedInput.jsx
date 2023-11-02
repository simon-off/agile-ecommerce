export default function ThemedInput({ children, className = "", label, ...inputAttributes }) {
  return (
    <label className={`themed-input ${className}`}>
      <span className="label">{label}</span>
      <input type="text" {...inputAttributes} />
      <span className="icon">{children}</span>
    </label>
  );
}
