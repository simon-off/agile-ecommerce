import styles from "./LoadingSpinner.module.scss";

export default function LoadingSpinner({
  diameter = "4rem",
  thickness = "1rem",
  color = "black",
  speed = "2s",
  delay = "200ms",
}) {
  return (
    <div
      class={styles.spinner}
      style={{
        "--diameter": diameter,
        "--thickness": thickness,
        "--color": color,
        "--speed": speed,
        "--delay": delay,
      }}
    ></div>
  );
}
