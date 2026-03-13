import './App.css'
import { BowlerTable } from './components/BowlerTable'
import { Heading } from './components/Heading'

/**
 * Root application component for the Bowling League mission.
 * This component composes the page heading and the table of bowlers
 * that are fetched from the ASP.NET API.
 */
function App() {
  return (
    <div className="app-shell">
      {/* High‑level page heading that explains what the user is viewing */}
      <Heading />

      {/* Main content area that displays the bowler table */}
      <main className="app-main">
        <BowlerTable />
      </main>
    </div>
  )
}

export default App
