using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using System;

public class VoiceSpells : MonoBehaviour
{
    private KeywordRecognizer recognizer;
    private Dictionary<string, Action> keywords;

    public GameObject freezePrefab;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    void Start()
    {
        keywords = new Dictionary<string, Action>(StringComparer.Ordinal)
        {
            // English
            { "fireball", CastFireball },
            { "freeze", CastFreeze },
            { "magic missile", CastMagicMissile },

            // Japanese samples
            { "ファイアボール", CastFireball }
        };

        recognizer = new KeywordRecognizer(keywords.Keys.ToArray(), ConfidenceLevel.Medium); // dễ test hơn
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
        recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log($"Heard: '{args.text}'  Confidence: {args.confidence}");
        if (keywords.TryGetValue(args.text, out var action))
            action?.Invoke();
    }

    void CastFireball()
    {
        Debug.Log("Cast Fireball!");
        if (bulletPrefab && shootPoint)
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    void CastFreeze()
    {
        Debug.Log("Cast Freeze!");
        if (freezePrefab && shootPoint)
            Instantiate(freezePrefab, shootPoint.position, shootPoint.rotation);
    }

    void CastMagicMissile() { Debug.Log("Cast Magic Missile!"); }

    void OnDestroy()
    {
        if (recognizer != null)
        {
            if (recognizer.IsRunning) recognizer.Stop();
            recognizer.OnPhraseRecognized -= OnPhraseRecognized;
            recognizer.Dispose();
        }
    }
}
