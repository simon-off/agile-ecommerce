import styles from "./LoadingSpinner.module.scss";

export default function LoadingSpinner({
  margin = "auto",
  diameter = "4rem",
  thickness = "1.25rem",
  color = "black",
  speed = "2s",
  delay = "200ms",
}) {
  return (
    <div
      class={styles.spinner}
      style={{
        "--margin": margin,
        "--diameter": diameter,
        "--thickness": thickness,
        "--color": color,
        "--speed": speed,
        "--delay": delay,
      }}
    ></div>
  );
}
