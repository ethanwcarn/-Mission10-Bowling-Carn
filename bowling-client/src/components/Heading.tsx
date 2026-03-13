/**
 * Simple, descriptive heading for the Bowling League page.
 * This component is kept separate so it can be reused or restyled
 * without touching the rest of the layout.
 */
export function Heading() {
  return (
    <header className="app-header">
      <h1 className="app-title">Bowling League – Marlins &amp; Sharks Bowlers</h1>
      <p className="app-subtitle">
        Listing bowlers and their contact information from the BowlingLeague database.
      </p>
    </header>
  )
}

